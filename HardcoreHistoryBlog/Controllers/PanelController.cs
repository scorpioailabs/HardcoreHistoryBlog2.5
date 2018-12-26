using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Core;
using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.Models.Blog_Models;
using HardcoreHistoryBlog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using PagedList;

namespace HardcoreHistoryBlog.Controllers
{
    public class PanelController : Controller
    {

        private IRepository _repo;
        private IFileManager _fileManager;  

        public PanelController(
            IFileManager fileManager,
            IRepository repo
            ) 
        {
            _fileManager = fileManager;
            _repo = repo;
        }

        [Authorize(Roles ="Admin")]


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
            var post = _repo.GetPost((int)id);
            return View(new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Short_Description = post.Short_Description,
                CurrentImage = post.Image,
                Content = post.Content,
                Category = post.Category,
                Tags = post.Tags
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            var post = new Post
            {
                Id = vm.Id,
                Title = vm.Title,
                Content = vm.Content,
                Short_Description = vm.Short_Description,
                Category = vm.Category,
                Tags = vm.Tags,
                Image = await _fileManager.SaveImage(vm.Image)
            };

            _repo.UpdatePost(post);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()

        {
            return View(new PostViewModel());
        }              

        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel vm)
        {
            var post = new Post
            {
                Id = vm.Id,
                ClientFirstName = vm.ClientFirstName, 
                Title = vm.Title,
                Content = vm.Content,
                Short_Description = vm.Short_Description,
                Category = vm.Category,
                Tags = vm.Tags, 
                Image = await _fileManager.SaveImage(vm.Image)

            };
            _repo.AddPost(post);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(post);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePost((int)id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}