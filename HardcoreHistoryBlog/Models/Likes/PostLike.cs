using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models.Likes
{
    public class PostLike : Like
    {
        public int PostId { get; set; }
        public int CustomerId { get; set; }
    }
}
