using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Models;

namespace HardcoreHistoryBlog.Core
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetComments(int count);
        IEnumerable<Comment> GetMostLikedComments(int count);
    }
}
