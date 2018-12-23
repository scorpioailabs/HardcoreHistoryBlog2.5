using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models.Likes
{
    public class SubcommentLike : Like
    {
        public int SubcommentId { get; set; } 
    }
}
