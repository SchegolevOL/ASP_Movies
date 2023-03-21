using ASP_Movies.Models;
using ASP_Movies.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP_Movies.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> Search(string title)
		{
			MovieApiService movieApiService = new MovieApiService();
			
			ViewBag.MovieTitle = title;
			ViewBag.Result = await movieApiService.SearchByTitleAsync(title);


			return View();
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