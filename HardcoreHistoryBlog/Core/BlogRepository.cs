using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Sql;
using HardcoreHistoryBlog.Models.Blog_Models;
using HardcoreHistoryBlog.Data;
using Microsoft.EntityFrameworkCore;

namespace HardcoreHistoryBlog.Core
{
    public class BlogRepository : Repository<Post>, IBlogRepository
    {
        public BlogRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Post> GetTopPosts(int count)
        {
            return ApplicationDbContext.Posts.OrderByDescending(c => c.Likes).Take(count).ToList();
        }

        public IEnumerable<Post> GetMostRecentPosts(int count)
        {
            return ApplicationDbContext.Posts.OrderByDescending(c => c.PostedOn).Take(count).ToList();
        }

        public IEnumerable<Post> GetPostsWithAuthors(int pageIndex, int pageSize = 6)
        {
            return ApplicationDbContext.Posts
                .Include(c => c.Author)
                .OrderBy(c => c.Author)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public IEnumerable<Post> GetPostsWithCategories(int pageIndex, int pageSize = 6)
        {
            return ApplicationDbContext.Posts
                .Include(c => c.Category)
                .OrderBy(c => c.Category)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public IEnumerable<Post> GetPostsWithTags(int pageIndex, int pageSize = 6)
        {
            return ApplicationDbContext.Posts
                .Include(c => c.PostTags)
                .OrderBy(c => c.PostTags)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
