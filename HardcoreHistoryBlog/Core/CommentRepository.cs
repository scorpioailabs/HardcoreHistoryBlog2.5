using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Models;
using HardcoreHistoryBlog.Data;
using Microsoft.EntityFrameworkCore;

namespace HardcoreHistoryBlog.Core
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context)
    : base(context)
        {
        }
        public IEnumerable<Comment> GetComments(int pageIndex, int pageSize = 6)
        {
            return ApplicationDbContext.Comments
                .Include(c => c.CommentedOn)
                .OrderBy(c => c.CommentedOn)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public IEnumerable<Comment> GetMostLikedComments(int pageIndex, int pageSize = 6)
        {
            return ApplicationDbContext.Comments
                .Include(c => c.Likes)
                .OrderBy(c => c.Likes)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Comment> GetComments(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetMostLikedComments(int count)
        {
            throw new NotImplementedException();
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
