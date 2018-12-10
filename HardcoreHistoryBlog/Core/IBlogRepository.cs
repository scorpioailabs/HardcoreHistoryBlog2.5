using HardcoreHistoryBlog.Models.Blog_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Core
{
    interface IBlogRepository : IRepository<Post>
    {
        IEnumerable<Post> GetTopPosts(int count);
        IEnumerable<Post> GetPostsWithAuthors(int pageIndex, int pageSize);
        IEnumerable<Post> GetMostRecentPosts(int count);
        IEnumerable<Post> GetPostsWithCategories(int pageIndex, int pageSize);
        IEnumerable<Post> GetPostsWithTags(int pageIndex, int pageSize);
    }
}
