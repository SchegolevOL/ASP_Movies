namespace ASP_Movies.Services
{
	public interface IMovieApiService
	{
		Task<string> SearchByTitleAsync(string title);
	}
}
