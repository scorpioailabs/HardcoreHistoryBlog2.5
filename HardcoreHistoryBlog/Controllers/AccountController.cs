using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Core;
using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.Models;
using HardcoreHistoryBlog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HardcoreHistoryBlog.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        //private readonly IRepository _repo;
        //private readonly IUserRepository _repoUser;

        public AccountController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            //_repo = repo;
            //_repoUser = repoUser;
        }


        public IActionResult Index(UsersViewModel vm)
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            string mail = user?.Email;
            string firstname = user?.FirstName;
            string lastname = user?.LastName;
            return View(new UsersViewModel
            {
                FirstName = firstname,
                LastName = lastname,
                Email = mail
            });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            {

                var user = new ApplicationUser { UserName = vm.Email, Email = vm.Email, FirstName = vm.FirstName, LastName = vm.LastName };
                var result = await _userManager.CreateAsync(user, vm.Password);
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Customer").Wait();
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
            }

            return View(vm);
        }



    }
}