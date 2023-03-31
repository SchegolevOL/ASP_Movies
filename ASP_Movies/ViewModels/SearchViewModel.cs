using ASP_Movies.Models;

namespace ASP_Movies.ViewModels
{
	public class SearchViewModel
	{
		public IEnumerable<Movie> Movies { get; set; }
		public string Title { get; set; }
		public int TotalResult { get; set; }
		public int TotalPage { get; set; }
		public int CurrentPage { get; set; }
		public string Response { get; set; }
	}
}
