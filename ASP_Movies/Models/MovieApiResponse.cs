

using System.Text.Json.Serialization;

namespace ASP_Movies.Models
{
	public class MovieApiResponse
	{
		[JsonPropertyName("Search")]
		public Movie[] Movies { get; set; }
		public string totalResults { get; set; }
		public string Response { get; set; }
		public string Error { get; set; }
	}
}
