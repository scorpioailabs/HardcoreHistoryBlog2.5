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
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }

        //    //[DisplayName("First Name")]
        //    //public string FirstName { get; set; }
        //    //[DisplayName("Second Name")]
        //    //public string LastName { get; set; }

        //    //[DisplayName("Email")]
        //    //[DataType(DataType.EmailAddress)]
        //    //public string Email { get; set; }
        //    public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
        //    public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
        //    public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
        //    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

        //    //public virtual ICollection<Client> Clients { get; set; }
        //    //public virtual ICollection<Customer> Customers { get; set; }
        //    //public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        //    //public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        //    //public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
        //    //public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

        //}
        //public class IdentityRole : IdentityRole
        //{
        //    public IdentityRole(string roleName) : base(roleName)
        //    {
        //    }

        //    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        //    public virtual ICollection<IdentityRoleClaim> RoleClaims { get; set; }
        //}
        //public class ApplicationUserRole : IdentityUserRole<string>
        //{
        //    public virtual ApplicationUser User { get; set; }
        //    public virtual IdentityRole Role { get; set; }
        //}
        //public class ApplicationUserClaim : IdentityUserClaim<string>
        //{
        //    public virtual ApplicationUser User { get; set; }
        //}

        //public class ApplicationUserLogin : IdentityUserLogin<string>
        //{
        //    public virtual ApplicationUser User { get; set; }
        //}

        //public class IdentityRoleClaim : IdentityRoleClaim<string>
        //{
        //    public virtual IdentityRole Role { get; set; }
        //}

        //public class ApplicationUserToken : IdentityUserToken<string>
        //{
        //    public virtual ApplicationUser User { get; set; }
        //}
    }
}
