using HardcoreHistoryBlog.Models;
using HardcoreHistoryBlog.Models.Blog_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Core
{
    public interface IBloggerRepository
    {
        bool Save(Blogger blogger);
        Blogger Details(int? Id);
        IEnumerable<Blogger> BloggerIEmum { get; }
        IQueryable<Blogger> BloggerList { get; }

        bool UniqueEmail(string email);
    }
}