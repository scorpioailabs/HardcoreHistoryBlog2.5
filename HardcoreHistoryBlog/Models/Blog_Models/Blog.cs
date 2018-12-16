using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models.Blog_Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        private string Url { get; set; }

        public ICollection<Post> Posts { get; set; }

    }
}
