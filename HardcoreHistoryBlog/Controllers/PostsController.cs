using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Core;
using HardcoreHistoryBlog.Models.Blog_Models;
using Microsoft.AspNetCore.Mvc;
using HardcoreHistoryBlog.Data; 

namespace HardcoreHistoryBlog.Controllers
{
    public class PostsController : Controller
    {

        private IRepository _repo;

        public PostsController(IRepository repo)
        {
            _repo = repo;  
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View(new Post());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            _repo.AddPost(post);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(post);
        }


    }
}