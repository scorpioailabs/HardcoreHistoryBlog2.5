using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models.Comments
{
    public class SubComment : Comment
    {
        public int MainCommentId { get; set; }  //1-many relationship with maincomment
    }
}
