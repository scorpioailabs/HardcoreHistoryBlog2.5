using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HardcoreHistoryBlog.Models.Blog_Models;

namespace HardcoreHistoryBlog.Models
{
    public class Member : ApplicationUser
    {

        public virtual ApplicationUser User { get; set; }

        public List<Post> CommentedOnPosts { get; set; }
    }
}
