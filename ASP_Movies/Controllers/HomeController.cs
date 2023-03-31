using ASP_Movies.Models;
using ASP_Movies.Services;
using ASP_Movies.ViewModels;
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
		public async Task<IActionResult> Search(string title, int page = 1)
		{
			SearchViewModel model;
			try
			{
				ViewBag.MovieTitle = title;
				var result = await _movieApiService.SearchByTitleAsync(title, page);
				int totalResult = int.Parse(result.totalResults);
				model = new SearchViewModel
				{
					Movies = result.Movies,
					Title = title,
					CurrentPage = page,
					TotalPage = (int)(Math.Ceiling(totalResult / 10.0)),
					TotalResult = totalResult,
					Response = result.Response
				};
				
			}
			catch (Exception e)
			{
				//e.Message = 
				Console.WriteLine(e);
				throw;
			}
			return View(model);
		}
		
		public async Task<IActionResult> Detail(string id)
		{
			var result = await _movieApiService.SearchByIdAsync(id);
			return View(result);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}