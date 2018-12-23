using HardcoreHistoryBlog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Core
{
    public class RoleRepository :IRoleRepository
    {
        private ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public IEnumerable<ApplicationRole> RoleIEnum
        {
            get { return _context.Roles; }
        }
    }
}
