using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HardcoreHistoryBlog.Models.Blog_Models;
using Microsoft.AspNetCore.Authorization;

namespace HardcoreHistoryBlog.Controllers
{
    public class PostController : Controller
    {
        private Post model = new Post();




        public IActionResult Index()
        {
            return View();
        }

        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Blogger")]
        public ActionResult Update(int? id, string title, string content, DateTime dateTime, string tags)
        {

            Post
            post = GetPost(id); 
            post.Title = title;
            post.Content = content;
            post.PostedOn = dateTime;
            post.PostTags.Clear();

            tags = tags ?? string.Empty;
            string[] tagNames = tags.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string tagName in tagNames)
            {
                post.PostTags.Add(GetTag(tagName));
            }

            if (!id.HasValue)
            {
                model.AddToPosts(post);
            }
            model.SaveChanges();
            return RedirectToAction("Details", new { id = post.PostId });
        }

        public Post GetPost(int? id)
        {
            return id.HasValue ? model.Blog.Posts.Where(x => x.PostId == id).First() : new Post() { PostId = -1 };
        }
        private PostTag GetTag(string tagName)
        {
            return model.PostTags.Where(x => x.Name == tagName).FirstOrDefault() ?? new PostTag() { Name = tagName };
        }

    }
}