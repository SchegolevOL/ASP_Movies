using ASP_Movies.Models;
using ASP_Movies.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ASP_Movies.Services
{
	

	public class MovieApiService : IMovieApiService
	{
		//public string BaseUrl { get; set; }
		//public string ApiKey { get; set; }
		public MovieApiOptions movieApiOptions { get; set; }
		public  HttpClient httpClient { get; set; }

		public MovieApiService(IHttpClientFactory httpClientFactory, IOptions<MovieApiOptions>options)
		{
			//BaseUrl = options.Value.BaseUrl;
			//ApiKey = options.Value.ApiKey;
			movieApiOptions = options.Value;
			httpClient = httpClientFactory.CreateClient();
		}

		public async Task<MovieApiResponse> SearchByTitleAsync(string title)
		{
			var response = await httpClient.GetAsync($"{movieApiOptions.BaseUrl}?s={title}%20man&apikey={movieApiOptions.ApiKey}");
			var result = await response.Content.ReadFromJsonAsync<MovieApiResponse>();//????????????
			
			return result;
		}
	}
}
