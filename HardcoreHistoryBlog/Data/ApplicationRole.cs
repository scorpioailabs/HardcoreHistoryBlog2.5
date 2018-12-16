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

        public ApplicationRole(string name, string description)
            : base(name)
        {
            this.Description = description;
        }

        public string Description { get; set; }

        public virtual ApplicationRole ParentRole { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
