using ASP_Movies.Models;

namespace ASP_Movies.Services
{
	public interface IMovieApiService
	{
		Task<MovieApiResponse> SearchByTitleAsync(string title);
		Task<Movie> SearchByIdAsync(string title);

	}
}
