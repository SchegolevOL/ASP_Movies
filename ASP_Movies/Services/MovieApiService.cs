using ASP_Movies.Models;
using ASP_Movies.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ASP_Movies.Services
{
	

	public class MovieApiService : IMovieApiService
	{
		public string BaseUrl { get; set; }
		public string ApiKey { get; set; }

		public  HttpClient httpClient { get; set; }

		public MovieApiService(IHttpClientFactory httpClientFactory, IOptions<MovieApiOptions>options)
		{
			BaseUrl = options.Value.BaseUrl;
			ApiKey = options.Value.ApiKey;
			httpClient = httpClientFactory.CreateClient();
		}

		public async Task<MovieApiResponse> SearchByTitleAsync(string title)
		{
			var response = await httpClient.GetAsync($"{BaseUrl}?s={title}%20man&apikey={ApiKey}");
			var result = await response.Content.ReadFromJsonAsync<MovieApiResponse>();//????????????
			
			return result;
		}
	}
}
