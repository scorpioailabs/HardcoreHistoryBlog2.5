using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Core;
using HardcoreHistoryBlog.Models.Blog_Models;
using Microsoft.AspNetCore.Mvc;
using HardcoreHistoryBlog.Data;
using Microsoft.AspNetCore.Authorization;
using HardcoreHistoryBlog.Models.Comments;
using HardcoreHistoryBlog.ViewModels;

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

        public IActionResult Index(string category)
        {
            var posts = string.IsNullOrEmpty(category) ? _repo.GetAllPosts() : _repo.GetAllPosts(category);
            // if no categories then get all posts, otherwise get all posts BY category
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

        [Authorize(Roles ="Customer,Blogger,Admin")]
        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Post", new { id = vm.PostId });
            }

            var post = _repo.GetPost(vm.PostId);
            if (vm.MainCommentId == 0)
            {
                post.MainComments = post.MainComments ?? new List<MainComment>();

                post.MainComments.Add(new MainComment
                {
                    Message = vm.Message,
                    Created = DateTime.Now,
                    Edited = DateTime.Now
                });
                _repo.UpdatePost(post);
            }
            else
            {
                var comment = new SubComment
                {
                    MainCommentId = vm.MainCommentId,
                    Message = vm.Message,
                    Created = DateTime.Now,
                    Edited = DateTime.Now
                };
                _repo.AddSubComment(comment);
            }
            await _repo.SaveChangesAsync();
            return RedirectToAction("Post", new { id = vm.PostId });
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> RemoveComment (int id)
        {
            _repo.RemoveComment(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Post");
        }

    }
}