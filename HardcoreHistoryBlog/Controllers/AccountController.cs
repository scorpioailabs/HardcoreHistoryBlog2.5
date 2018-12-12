using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.Core;

namespace HardcoreHistoryBlog.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBloggerRepository bloggerRepository;
        private readonly IBlogRepository blogRepository;
        




        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Me()
        {
            return View();
        }

    }
}