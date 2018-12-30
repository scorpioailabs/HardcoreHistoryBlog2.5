using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HardcoreHistoryBlog.Controllers
{
    public class AuthController : Controller
    {

        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Posts");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(vm);
            }
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
}