using HardcoreHistoryBlog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Core
{
    public interface IRoleRepository
    {
        IEnumerable<ApplicationRole> RoleIEnum { get; }
    }
}
