using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.Models;
using HardcoreHistoryBlog.Models.Blog_Models;
using Microsoft.EntityFrameworkCore;

namespace HardcoreHistoryBlog.Core
    {
        public interface IRepository
        {
            Post GetPost(int id); 
            List<Post> GetAllPosts();

            void AddPost(Post post);
            void UpdatePost(Post post);
            void RemovePost(int id);

            Task<bool> SaveChangesAsync();

        }
    }


