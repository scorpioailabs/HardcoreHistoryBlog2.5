using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Data;
using Microsoft.AspNetCore.Mvc;

namespace HardcoreHistoryBlog.Models.Blog_Models
{
    public class Post
    {
        internal IUrlHelper Url;

        public virtual int PostId { get; set; }
        public virtual string Title { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public virtual string Short_Description { get; set; }
        [DataType(DataType.MultilineText)]
        public virtual string Content { get; set; }
        public DateTime Posted { get; set; }
        public DateTime? Modified { get; set; }
        [Required(ErrorMessage = "At least one Category is required")]
        [DisplayName("Category:")]
        public string Category { get; set; }
        public string Tag { get; set; }
        public virtual Category Categories { get; set; }
        [Required(ErrorMessage = "Tag is required")]
        [DisplayName("Tags:")]
        public List<Tag> postTags { get; set; }
        public List<Comment> Comments { get; set; }
        [ForeignKey("BlogForeignKey")]
        public Blog Blog { get; set; }
        public List<Like> Likes { get; set; }
        public virtual IEnumerable<Category> GetCategories { get; set; }
        public virtual IEnumerable<Post> Posts { get; set; }
        public virtual Client Author { get; set; }

        public Post()
        {
            this.Posted = DateTime.Now;
            this.Modified = DateTime.Now;
        }
    }

    public class Client : ApplicationUser
    {
        public virtual ApplicationUser Author { get; set; }
        public virtual ApplicationRole Role { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
