using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Core;
using HardcoreHistoryBlog.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using HardcoreHistoryBlog.ViewModels;

namespace HardcoreHistoryBlog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private IRepository _repo;


        public AdminController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, IRepository repo)

        {
            _userManager = userManager;
            _roleManager = roleManager;
            _repo = repo;

        }


        public IActionResult Roles()
        {
            var roles = _repo.AllRoles();
            return View(roles);
        }



    }
}