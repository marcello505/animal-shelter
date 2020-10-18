using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ManagementApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace ManagementApplication.Controllers
{
    public class Home2Controller : Controller
    {
        private readonly ILogger<Home2Controller> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public Home2Controller(ILogger<Home2Controller> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl});
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);

            if(user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
                if (signInResult.Succeeded)
                {
                    return Redirect(loginModel?.ReturnUrl ?? "/Animal/Index");

                }
                ModelState.AddModelError("", "Password was not correct.");
            }
            else
            {
                ModelState.AddModelError("", "User was not found");
            }

            return View(loginModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
