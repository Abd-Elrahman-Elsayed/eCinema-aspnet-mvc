using eCinema.Data;
using eCinema.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace eCinema.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly AppDbContext appDbContext;

        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> signInManager, AppDbContext _appDbContext)
        {
            userManager = _userManager;
            this.signInManager = signInManager;
            appDbContext = _appDbContext;
        }

        //----------------------Registration-----------------------------------------------//

        private bool ExistedItem(string Email, string Username)
        {
            return appDbContext.Users.Any(u => u.Email == Email) ||
                   appDbContext.Users.Any(u => u.UserName == Username);
        }

        public IActionResult CheckExistItem(string Email, string Username)
        {
            return Json(!ExistedItem(Email,Username));
        }

        public IActionResult Register()
        {
            var Roles = appDbContext.Roles.Select(r=>r.Name).ToList();
            ViewBag.Roles = new SelectList(Roles);
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Register(AccountVM newAccount, string roleName)
		{
			if (ModelState.IsValid)
			{
				//map vm to identityuser
				IdentityUser user = new IdentityUser();
				user.UserName = newAccount.Username;
				user.Email = newAccount.Email;

				//use repository to add user to db
				IdentityResult result = await userManager.CreateAsync(user, newAccount.Password);
				if (result.Succeeded)
				{
					if (!User.IsInRole("Admin"))
					{
						await userManager.AddToRoleAsync(user, "Customer");
					}
                    else
                    {
						await userManager.AddToRoleAsync(user, roleName);
					}

					await signInManager.SignInAsync(user, false);                
					return RedirectToAction("Index", "Movie");
				}
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}

			}
			return View(newAccount);
		}

		//----------------------Login-----------------------------------------------//

		public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginObj, string? returnurl = "~/Movie/Index")
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginObj.Username);
                if(user != null)
                {
                    SignInResult result = await signInManager.PasswordSignInAsync(user, loginObj.Password, false, false);
                    if (result.Succeeded)
                    {
                        return LocalRedirect(returnurl);
                    }
                    ModelState.AddModelError("", "Wrong Username or Password!");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong Username or Password!");
                }
            }
            return View(loginObj);
        }

        //-----------------------------------Logout------------------------------//

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
