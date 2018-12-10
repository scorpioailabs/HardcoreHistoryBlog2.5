using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models.Blog_Models
{
    public class Like
    {
        public int LikeId { get; set; }
        public bool Liked { get; set; }

        public int PostForeignKey { get; set; }
        [ForeignKey("PostForeignKey")]
        public Post Post { get; set; }

        public int CommentForeignKey { get; set; }
        [ForeignKey("CommentForeignKey")]
        public Comment Comment { get; set; }

    }
}
