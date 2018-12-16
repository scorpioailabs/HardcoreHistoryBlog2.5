using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HardcoreHistoryBlog.Models.Blog_Models;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using HardcoreHistoryBlog.Data;

namespace HardcoreHistoryBlog.Controllers
{
    public class PostController : Controller
    {
        private Post model = new Post();
        private PostTag postTag = new PostTag();

        public PostTag PostTag { get => postTag; set => postTag = value; }

        public IActionResult Index()
        {
            return View();
        }

        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Update(int? id, string title, string content, DateTime dateTime, string tags)
        {

            Post
            post = GetPost(id); 
            post.Title = title;
            post.Content = content;
            post.PostedOn = dateTime;
            post.postTags.Clear();

            tags = tags ?? string.Empty;
            string[] tagNames = tags.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string tagName in tagNames)
            {
                post.postTags.Add(GetTag(tagName));
            }

            if (!id.HasValue)
            {
                model.AddToPosts(post);
            }
            model.SaveChanges();
            return RedirectToAction("Details", new { id = post.PostId });
        }

        public ActionResult Edit(int? id)
        {
            Post post = GetPost(id);
            StringBuilder categoryList = new StringBuilder();
            foreach (PostTag tag in post.postTags)
            {
                categoryList.AppendFormat("{0} ", tag.Name);

            }
            ViewBag.Categories = categoryList.ToString();
            return View(post);
        }

        public Post GetPost(int? id)
        {
            return id.HasValue ? model.Blog.Posts.Where(x => x.PostId == id).First() : new Post() { PostId = -1 };
        }
        private PostTag GetTag(string tagName)  
        {
            return model.postTags.Where(x => x.Name == tagName).FirstOrDefault() ?? new PostTag() { Name = tagName };
        }

    }
}