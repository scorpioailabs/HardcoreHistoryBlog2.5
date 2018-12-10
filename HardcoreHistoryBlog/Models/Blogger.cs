using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.Models.Blog_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models
{
    public class Blogger
    {
        public int BloggerId { get; set; }

        public virtual ApplicationUser User { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Second Name")]
        public string LastName { get; set; }

        [InverseProperty("Author")]
        public List<Post> AuthoredPosts { get; set; }
        [InverseProperty("Contributor")]
        public List<Post> ContributedToPosts { get; set; }
    }
}
