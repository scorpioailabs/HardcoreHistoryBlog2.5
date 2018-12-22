using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models.Likes
{
    public class MainCommentLike : Like
    {
        public int MainCommentId { get; set; }
        public int CustomerId { get; set; }
    }
}
