using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.Models.Blog_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models
{
    public class Blogger : ApplicationUser
    {
        public virtual ApplicationUser User { get; set; }
        public List<Post> AuthoredPosts { get; set; }
        public List<Post> ContributedToPosts { get; set; }
   
    }
}
