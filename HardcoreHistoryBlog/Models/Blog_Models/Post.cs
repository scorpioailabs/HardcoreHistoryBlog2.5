using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.Models.Comments;
using HardcoreHistoryBlog.Models.Likes;
using Microsoft.AspNetCore.Mvc;

namespace HardcoreHistoryBlog.Models.Blog_Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public virtual string Title { get; set; } = "";
        public virtual string Short_Description { get; set; }
        public string Image { get; set; } = "";

        [DataType(DataType.MultilineText)]
        public virtual string Content { get; set; } = "";

        public string Category { get; set; } = "";
        public string Tags { get; set; } = "";

        public DateTime Posted { get; set; } = DateTime.Now;
        public DateTime? Modified { get; set; } = DateTime.Now;
        public virtual ApplicationUser User { get; set; }
        public List<MainComment> MainComments { get; set; }
        public string UserId { get; set; }
    }

}
