using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Models;

namespace HardcoreHistoryBlog.Data
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Blogger> Bloggers { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }

        ///// <summary>
        ///// Navigation property for the roles this user belongs to.
        ///// </summary>
        //public virtual ICollection<IdentityUserRole<int>> Roles { get; } = new List<IdentityUserRole<int>>();

        ///// <summary>
        ///// Navigation property for the claims this user possesses.
        ///// </summary>
        //public virtual ICollection<IdentityUserClaim<int>> Claims { get; } = new List<IdentityUserClaim<int>>();

        ///// <summary>
        ///// Navigation property for this users login accounts.
        ///// </summary>
        //public virtual ICollection<IdentityUserLogin<int>> Logins { get; } = new List<IdentityUserLogin<int>>();
    }
}
