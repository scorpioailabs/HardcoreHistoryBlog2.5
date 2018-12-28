using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Data
{
    public class ApplicationRole : IdentityRole

    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string name)
            : base(name)
        { }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
