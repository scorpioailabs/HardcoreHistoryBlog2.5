using HardcoreHistoryBlog.Models.Blog_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }

        public int PostForeignKey { get; set; }
        [ForeignKey("PostForeignKey")]
        public Post Post { get; set; }

        public List<Like> Likes { get; set; }        
    }
}
