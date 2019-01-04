using HardcoreHistoryBlog.Models.Blog_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models.Comments
{
    public class SubComment : Comment
    {
        [Required]
        public int MainCommentId { get; set; }  //1-many relationship with maincomment
        public string UserId { get; internal set; }
    }
}
