using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Core;
using HardcoreHistoryBlog.Models.Blog_Models;
using Microsoft.AspNetCore.Mvc;
using HardcoreHistoryBlog.Data;
using Microsoft.AspNetCore.Authorization;

namespace HardcoreHistoryBlog.Controllers
{
    public class PostsController : Controller
    {

        private IRepository _repo;
        private IFileManager _fileManager;

        public PostsController( 
            IFileManager fileManager,
            IRepository repo
            )
        {
            _fileManager = fileManager;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var posts = _repo.GetAllPosts();
            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = _repo.GetPost(id);
            return View(post);
        }

        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.')+1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }

    }
}