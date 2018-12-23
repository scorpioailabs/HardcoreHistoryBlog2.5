using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Data
{
    public class RoleStore : RoleStore<ApplicationRole>
    {
        public RoleStore(ApplicationDbContext context) : base(context)
        {
        }
    }

}
