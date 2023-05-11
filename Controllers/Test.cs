using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eCinema.Controllers
{
    public class Test : Controller
    {
        public IActionResult Index()
        {
            ViewData["num"] = 7;
            return View();
        }
    }
}
