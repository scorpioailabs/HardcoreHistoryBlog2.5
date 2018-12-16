using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardcoreHistoryBlog.Data
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Blogger> Bloggers { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        [ForeignKey("Role")]
        public virtual ApplicationRole ApplicationRole { get; internal set; }
    }
}
