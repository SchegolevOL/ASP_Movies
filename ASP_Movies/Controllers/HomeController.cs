using ASP_Movies.Models;
using ASP_Movies.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP_Movies.Controllers
{
	public class HomeController : Controller
	{

		private readonly IMovieApiService _movieApiService;

		//public HomeController(ILogger<HomeController> logger)
		//{
		//	_logger = logger;
		//}

		public HomeController(IMovieApiService movieApiService)
		{
			_movieApiService = movieApiService;
		}

		public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> Search(string title)
		{
			MovieApiResponse result;
			try
			{
				ViewBag.MovieTitle = title;
				result = await _movieApiService.SearchByTitleAsync(title);
			}
			catch (Exception e)
			{
				//e.Message = 
				Console.WriteLine(e);
				throw;
			}
			return View(result);
		}
		public IActionResult Detail()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}