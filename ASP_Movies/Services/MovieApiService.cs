namespace ASP_Movies.Services
{
	public class MovieApiService
	{
		public string BaseUrl { get; set; }
		public string ApiKey { get; set; }
		public  HttpClient httpClient { get; set; }

		public MovieApiService()
		{
			BaseUrl = "https://omdbapi.com/";
			ApiKey = "5b9b7798";
			httpClient = new HttpClient();
		}

		public async Task<string> SearchByTitleAsync(string title)
		{
			var response = await httpClient.GetAsync($"{BaseUrl}?s={title}%20man&apikey={ApiKey}");
			var result = await response.Content.ReadAsStringAsync();
			return result;
		}
	}
}
