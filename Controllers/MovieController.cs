using eCinema.Data.Base;
using eCinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eCinema.Controllers
{
    public class MovieController : Controller
	{
		public readonly IEntityBaseRepository<Movie> _context;
		public MovieController(IEntityBaseRepository<Movie> context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.GetAllAsync());
		}

        public async Task<IActionResult> Details(int id)
        {
			var Movie = await _context.GetByIdAsync(id);
			if(Movie is null)
			{
				return View("Not Found");
			}
			var ActorMovies = Movie.Actor_Movies;
			List<Actor> ActorList = new List<Actor>();
			foreach (var item in ActorMovies)
			{
				ActorList.Add(item.Actor);
			}
			ViewBag.ActorList = ActorList;
			ViewBag.Producer = Movie.Producer;
            return View(Movie);
        }
    }
}
