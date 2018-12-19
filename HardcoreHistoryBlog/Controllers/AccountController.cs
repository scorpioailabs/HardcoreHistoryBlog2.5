using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.Core;
using HardcoreHistoryBlog.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI.Services;
using static HardcoreHistoryBlog.Models.AccountVMs;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Encodings.Web;

namespace HardcoreHistoryBlog.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context) 
        {
            _context = context;
        }
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IBlogRepository repositoryBlog;
        private readonly ICommentRepository repositoryComment;
        private readonly ILogger<RegisterViewModel> _logger;
        private readonly IEmailSender _emailSender;

        public AccountController(IBlogRepository repoPost, ICommentRepository repoComment)
        {
            repositoryBlog = repoPost;
            repositoryComment = repoComment;
        }
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            ILogger<RegisterViewModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _emailSender = emailSender;
        }


        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model, string returnUrl = null)
        {
            return View();
        }

    }
}