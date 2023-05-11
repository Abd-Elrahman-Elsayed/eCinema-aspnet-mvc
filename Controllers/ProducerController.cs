using eCinema.Data;
using eCinema.Data.Base;
using eCinema.Models;
using eCinema.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Controllers
{
    public class ProducerController : Controller
	{
		public readonly IEntityBaseRepository<Producer> _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;

        public ProducerController(IEntityBaseRepository<Producer> context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
		{
			_context = context;
            _hosting = hosting;
        }

		public async Task<IActionResult> Index()
		{
			return View(await _context.GetAllAsync());
		}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProducerVM ProducerVM)
        {
            if (ModelState.IsValid)
            {
                string uploads = Path.Combine(_hosting.WebRootPath, "uploads");
                string fileName = ProducerVM.File.FileName;
                string fullPath = Path.Combine(uploads, fileName);
                ProducerVM.File.CopyTo(new FileStream(fullPath, FileMode.Create));

                ProducerVM.Producer.ImageUrl = "/uploads/" + fileName;
                await _context.AddAsync(ProducerVM.Producer);
                return RedirectToAction("Index");
            }
            else
            {
                return View(ProducerVM);
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            var Producer = await _context.GetByIdAsync(id);
            if (Producer is null)
            {
                return View("Not Found");
            }
            return View(Producer);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ProducerVM = new ProducerVM() { Producer = await _context.GetByIdAsync(id) };
            return View(ProducerVM);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ProducerVM ProducerVM)
        {
            if (ModelState.IsValid)
            {
                if (ProducerVM.File != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, "uploads");
                    string fileName = ProducerVM.File.FileName;
                    string fullPath = Path.Combine(uploads, fileName);
                    ProducerVM.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                    ProducerVM.Producer.ImageUrl = "/uploads/" + fileName;
                }
                await _context.UpdateAsync(ProducerVM.Producer);
                return RedirectToAction("Index");
            }
            else
            {
                return View(ProducerVM);
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
