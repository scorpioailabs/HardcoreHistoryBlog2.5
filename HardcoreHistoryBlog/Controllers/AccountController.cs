using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Core;
using HardcoreHistoryBlog.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HardcoreHistoryBlog.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IRepository _repo;

        public AccountController(IRepository repo, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}