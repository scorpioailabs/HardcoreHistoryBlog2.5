using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Data
{
    public class UserStore : UserStore<ApplicationUser>
    {
        public UserStore(ApplicationDbContext context) : base(context)
        {
        }
    }
}
