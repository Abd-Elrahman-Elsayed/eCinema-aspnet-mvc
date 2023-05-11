using eCinema.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Controllers
{
	public class RoleController : Controller
	{
		private readonly RoleManager<IdentityRole> roleManager;

		public RoleController(RoleManager<IdentityRole> _roleManager)
		{
			roleManager = _roleManager;
		}

		public IActionResult AddRole()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddRole(RoleVM roleVM)
		{
			if (ModelState.IsValid)
			{
				IdentityRole role = new IdentityRole()
				{
					Name = roleVM.RoleName
				};

				IdentityResult result = await roleManager.CreateAsync(role);
				if (!result.Succeeded)
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View();
		}
	}
}
