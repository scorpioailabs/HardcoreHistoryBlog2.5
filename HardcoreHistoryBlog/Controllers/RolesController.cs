using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Core;
using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HardcoreHistoryBlog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private IRepository _repo;
        private readonly ApplicationDbContext _context;


        public RolesController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, IRepository repo, ApplicationDbContext context)

        {
            _userManager = userManager;
            _roleManager = roleManager;
            _repo = repo;
            _context = context;

        }
        public IActionResult Index()
        {
            var roles = _repo.AllRoles();
            return View(roles);
        }

        [AutoValidateAntiforgeryToken]

        public ActionResult Details(string id)
        {
            var role = _context.Roles.Find(id);
            if (role == null)
            {
                return RedirectToAction("Index");
            }
            return View(role);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            {
                var role = new ApplicationRole
                { Name = vm.Name };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    _repo.AddRole(role);
                    return RedirectToAction("Index");
                }
                else
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                return View(vm);
            }
        }

        [HttpGet]
        public ActionResult Delete(string Id)
        {
            var role = _context.Roles.Find(Id);
            if (role == null)
            {
                return RedirectToAction("Index");
            }
            return View(role);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Delete([Bind(include: "Id,Name")]ApplicationRole myRole)
        {
            ApplicationRole role = _context.Roles.Find(myRole.Id);
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}