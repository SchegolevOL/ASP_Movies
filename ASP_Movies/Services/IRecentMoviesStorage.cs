using ASP_Movies.Models;

namespace ASP_Movies.Services
{
	public interface IRecentMoviesStorage
	{
		IEnumerable<Movie> GetRecentMovies();
		void Add(Movie movie);
	}
}
