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
        public int BloggerId { get; set; }

        public virtual ApplicationUser User { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Second Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }  

        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Last login")]
        public DateTime Last_Login { get; set; }  
        [DisplayName("Role:")]
        public int RoleId { get; set; }
        
        public List<Post> AuthoredPosts { get; set; }
        public List<Post> ContributedToPosts { get; set; }
        public string UserName { get; internal set; }
    }
}
