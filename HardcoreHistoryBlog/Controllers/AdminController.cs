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
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUserRepository _repoUser;
        private readonly IRoleRepository _repoRole;

        public AdminController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, IUserRepository repoUser, IRoleRepository repoRole)

        {
            _userManager = userManager;
            _roleManager = roleManager;
            _repoUser = repoUser;
            _repoRole = repoRole;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Users(UsersViewModel vm)
        {
            var UsersViewModel = _repoUser.UserList.OrderBy(p => p.FirstName)
            .OrderByDescending(p => p.FirstName); ;
            return View(UsersViewModel); 
        }
    }
}