using ASP_Movies.Options;
using ASP_Movies.Services;

namespace ASP_Movies.Extension
{
	public static class ServiceCollectionExtension
	{
		public static IServiceCollection AddMovieApi(this IServiceCollection services, Action<MovieApiOptions> options)
		{
			services.AddScoped<IMovieApiService, MovieApiService>();
			services.Configure(options);
			return services;
		}
	}
}
