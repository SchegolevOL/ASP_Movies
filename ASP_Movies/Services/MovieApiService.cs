using System.Text.Json;
using ASP_Movies.Models;
using ASP_Movies.Options;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace ASP_Movies.Services
{


	public class MovieApiService : IMovieApiService
	{
		//public string BaseUrl { get; set; }
		//public string ApiKey { get; set; }
		public MovieApiOptions movieApiOptions { get; set; }
		public HttpClient httpClient { get; set; }
		public IMemoryCache memoryCache { get; set; }//кэш

		public MovieApiService(IHttpClientFactory httpClientFactory, IOptions<MovieApiOptions> options, IMemoryCache memoryCache)
		{
			//BaseUrl = options.Value.BaseUrl;
			//ApiKey = options.Value.ApiKey;
			movieApiOptions = options.Value;
			httpClient = httpClientFactory.CreateClient();
			this.memoryCache = memoryCache;
		}

		public async Task<MovieApiResponse> SearchByTitleAsync(string title, int page = 1)
		{
			title = title.ToLower();//все строчные

			MovieApiResponse result;
			
				var response = await httpClient.
					GetAsync($"{movieApiOptions.BaseUrl}?s={title}&apikey={movieApiOptions.ApiKey}&page={page}");

				result = await response.Content.ReadFromJsonAsync<MovieApiResponse>();

				
				if (result.Response == "False")
				{
					throw new Exception(result.Error);
				}

				var timeExpire = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(1));//время жизни кэша
				memoryCache.Set(title, result, timeExpire );
			

			return result;
		}

		public async Task<Movie> SearchByIdAsync(string id)
		{
			Movie result;
			if (!memoryCache.TryGetValue(id, out result))
			{
				var response = await httpClient.GetAsync($"{movieApiOptions.BaseUrl}?i={id}&apikey={movieApiOptions.ApiKey}");
				result = await response.Content.ReadFromJsonAsync<Movie>();
				if (result.Response == "False")
				{
					throw new Exception(result.Error);
				}
				memoryCache.Set(id, result);
			}

			return result;
		}
	}
}
