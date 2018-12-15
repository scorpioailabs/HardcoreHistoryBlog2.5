using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.Core;
using HardcoreHistoryBlog.Models;

namespace HardcoreHistoryBlog.Controllers
{
    public class AccountController : Controller
    {

        private readonly IBlogRepository repositoryBlog;
        private readonly ICommentRepository repositoryComment; 
        public AccountController (IBlogRepository repoPost, ICommentRepository repoComment)
        {
            repositoryBlog = repoPost;
            repositoryComment = repoComment;
        }

        [Authorize(Roles = "Blogger")]
        public ActionResult Index()
        {
            DateTime Last24Hours = DateTime.Now.Date.AddHours(-24);
            DashboardVM model = new DashboardVM();
            return View();
        }

    }
}