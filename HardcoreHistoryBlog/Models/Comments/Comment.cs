using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.Models.Blog_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models.Comments
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string By { get; set; }
    }
}
