using System.Collections.Concurrent;
using ASP_Movies.Models;

namespace ASP_Movies.Services
{
	public class RecentMoviesStorage: IRecentMoviesStorage
	{
		ConcurrentQueue<Movie> _recentMovies = new ConcurrentQueue<Movie>();//

		public IEnumerable<Movie> GetRecentMovies()
		{
			return this._recentMovies.Take(4);
		}

		public void Add(Movie movie)
		{
			if (!_recentMovies.Contains(movie))
			{
				_recentMovies.Enqueue(movie);
			}
			if (_recentMovies.Count>4)
			{
				_recentMovies.TryDequeue(out Movie trash);
			}
		}
	}
}
