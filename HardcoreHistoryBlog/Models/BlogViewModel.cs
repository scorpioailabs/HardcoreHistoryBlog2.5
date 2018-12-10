using HardcoreHistoryBlog.Models.Blog_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Core;
using HardcoreHistoryBlog.Data;

namespace HardcoreHistoryBlog.Models
{
    public class BlogViewModel
    {
        public int Id { get; set; } 
        public Post Post { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }

}
