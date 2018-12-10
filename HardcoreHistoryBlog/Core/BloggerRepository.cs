using HardcoreHistoryBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Data;

namespace HardcoreHistoryBlog.Core
{
    public class BloggerRepository : Repository<Blogger>, IBloggerRepository
    {
        public BloggerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
