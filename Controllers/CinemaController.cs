using eCinema.Data.Interfaces;
using eCinema.Models;
using eCinema.ViewModels;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace eCinema.Controllers
{
    public class CinemaController : Controller
	{
		public readonly IEntity<Cinema> _context;
		private readonly IHostingEnvironment _hosting;

		public CinemaController(IEntity<Cinema> context, IHostingEnvironment hostingEnvironment)
		{
			_context = context;
			_hosting = hostingEnvironment;
		}
		public async Task<IActionResult> Index()
		{
			var AllCinemas = await _context.GetAllAsync();
			return View(AllCinemas);
		}

		public async Task<IActionResult> Details(int id)
		{
			return View(await _context.GetByIdAsync(id));
		}

		public async Task<IActionResult> Edit(int id)
		{
			CinemaVM cinemaVM = new CinemaVM() { Cinema = await _context.GetByIdAsync(id) };
			return View(cinemaVM);
		}


		[HttpPost]
		public async Task<IActionResult> Edit(CinemaVM cinemaVM)
		{
			if (ModelState.IsValid)
			{
				if (cinemaVM.File != null)
				{
					string uploads = Path.Combine(_hosting.WebRootPath, "uploads");
					string fileName = cinemaVM.File.FileName;
					string fullPath = Path.Combine(uploads, fileName);

					cinemaVM.File.CopyTo(new FileStream(fullPath,FileMode.Create));
					cinemaVM.Cinema.Logo = "/uploads/" + fileName;
				}
				await _context.UpdateAsync(cinemaVM.Cinema);
				return RedirectToAction("Index");
			}
			return View(cinemaVM);
		}

		public async Task<IActionResult> Delete(int id)
		{
			return View(await _context.GetByIdAsync(id));
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirm(int id)
		{
			await _context.DeleteAsync(id);
			return RedirectToAction("index");
		}
	}
}
