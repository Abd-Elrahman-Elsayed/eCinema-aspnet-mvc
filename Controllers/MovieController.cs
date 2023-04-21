using eCinema.Data.Interfaces;
using eCinema.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Controllers
{
    public class MovieController : Controller
	{
		public readonly IEntity<Movie> _context;
		public MovieController(IEntity<Movie> context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var AllMovies = await _context.GetAllAsync();
			return View(AllMovies);
		}
	}
}
