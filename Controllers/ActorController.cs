using eCinema.Data;
using eCinema.Data.Interfaces;
using eCinema.Models;
using eCinema.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace eCinema.Controllers
{
    [Authorize]
    public class ActorController : Controller
    {
        public readonly IEntity<Actor> _context;
        public readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;

        public ActorController(IEntity<Actor> context, IHostingEnvironment hosting)
        {
            _context = context;
            _hosting= hosting;
        }

        public async Task<IActionResult> Index()
        {
            List<Actor> AllActors = await _context.GetAllAsync();
            return View(AllActors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActorVM actorVM)
        {
            if (ModelState.IsValid)
            {
                string uploads = Path.Combine(_hosting.WebRootPath, "uploads");
                string fileName = actorVM.File.FileName;
                string fullPath = Path.Combine(uploads, fileName);
                actorVM.File.CopyTo(new FileStream(fullPath,FileMode.Create));

				var Actor = actorVM.Actor;
				Actor.ImageUrl = "/uploads/"+fileName;
				await _context.AddAsync(Actor);
				return RedirectToAction("Index");
            }
            else
            {
                throw new Exception();
            }
            
        }

        public async Task<IActionResult> Details(int id)
        {
            var Actor = await _context.GetByIdAsync(id);
            if(Actor is null)
            {
                return RedirectToAction("Index");
            }
            return View(Actor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actorVM = new ActorVM() { Actor = await _context.GetByIdAsync(id) };
            return View(actorVM);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ActorVM actorVM)
        {
            if (ModelState.IsValid)
            {
				if (actorVM.File != null)
				{
					string uploads = Path.Combine(_hosting.WebRootPath, "uploads");
					string fileName = actorVM.File.FileName;
					string fullPath = Path.Combine(uploads, fileName);
					actorVM.File.CopyTo(new FileStream(fullPath, FileMode.Create));
					actorVM.Actor.ImageUrl = "/uploads/" + fileName;
				}
				await _context.UpdateAsync(actorVM.Actor);
				return RedirectToAction("Index");
            }
            else
            {
				throw new Exception();
			}
		}

		public async Task<IActionResult> Delete(int id)
        {
            return View(await _context.GetByIdAsync(id));
        }


        [HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _context.DeleteAsync(id);
			return RedirectToAction("Index");
		}
	}
}
