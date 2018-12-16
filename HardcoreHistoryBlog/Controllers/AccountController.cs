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

        public ActionResult Index()
        {
            return View();
        }

    }
}