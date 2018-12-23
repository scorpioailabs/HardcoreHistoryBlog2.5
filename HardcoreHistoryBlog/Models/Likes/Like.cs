using HardcoreHistoryBlog.Models.Blog_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models.Likes
{
    public class Like
    {
        public int Id { get; set; }
        public virtual Client Client { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
