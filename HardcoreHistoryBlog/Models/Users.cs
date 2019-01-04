using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.Models.Blog_Models;
using HardcoreHistoryBlog.Models.Comments;
using HardcoreHistoryBlog.Models.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models
{
    public class Users
    {
        public class Client : ApplicationUser
        {
            public virtual ApplicationUser Author { get; set; }
            public virtual ApplicationRole Role { get; set; }
            public virtual ICollection<Post> Posts { get; set; }
        }

        public class Customer : ApplicationUser
        {
            public virtual ApplicationRole Role { get; set; }
            public virtual ICollection<Post> Posts { get; set; }
            public virtual ICollection<Like> Likes { get; set; }
            public virtual ICollection<Comment> Comments { get; set; }
        }
    }
}
