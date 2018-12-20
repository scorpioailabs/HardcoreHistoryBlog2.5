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
            var posts = _repo.GetAllPosts();
            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = _repo.GetPost(id);
            return View(post);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _repo.GetPost((int)id);  //casting int
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            _repo.UpdatePost(post);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Post());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Post post) 
        {
            _repo.AddPost(post);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(post);
        }


    }
}