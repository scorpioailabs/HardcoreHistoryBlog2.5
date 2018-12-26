using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Data
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public string RoleName { get; set; }         
    }
}
