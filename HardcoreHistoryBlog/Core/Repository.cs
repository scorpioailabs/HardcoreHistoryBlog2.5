using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.Models;
using HardcoreHistoryBlog.Models.Blog_Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using HardcoreHistoryBlog.Models.Comments;
using Microsoft.AspNetCore.Identity;

namespace HardcoreHistoryBlog.Core
{
    public class Repository : IRepository
    {
        private ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;


        public void AddPost(Post post)
        {

            _context.Posts.Add(post);
        }

        public List<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        public List<Post> GetAllPosts(string category)
        {
            Func<Post, bool> InCategory = (post) => { return post.Category.ToLower().Equals(category.ToLower()); };
            return _context.Posts
                .Where(post => InCategory(post))
                .ToList();
        }

        public Post GetPost(int id)
        {
            return _context.Posts
                .Include(p => p.MainComments)
                    .ThenInclude(mc => mc.SubComments)
                .FirstOrDefault(p => p.Id == id);
        }

        public void RemovePost(int id)
        {
            _context.Posts.Remove(GetPost(id));
        }


        public void UpdatePost(Post post)
        {
            _context.Posts.Update(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public void AddSubComment(SubComment comment)
        {
            _context.SubComments.Add(comment);
        }
        public MainComment GetComment(int id)
        {
            return _context.MainComments
                .Include(c => c.Id) 
                .FirstOrDefault(c => c.Id == id);
        }
        public void RemoveComment(int id)
        {
            _context.MainComments.Remove(GetComment(id));
        }

        public IEnumerable<ApplicationUser> Users { get; set; }

        public void GetUsers()
        {
            var customers = _userManager.GetUsersInRoleAsync("Customer").Result;
            var admins = _userManager.GetUsersInRoleAsync("Admin").Result;              
        }

        public void AddUser(ApplicationUser user)
        {
            _context.Add(user);
        }

        public void UpdateUser(ApplicationUser user) 
        {
            _context.Update(user);
        }

        public List<ApplicationRole> AllRoles()
        {
            return _context.Roles.ToList();
        }

        public void GetRole(string id)
        {
            _context.Roles.Find(id);
        }

        public void AddRole(ApplicationRole role)
        {
            _context.Roles.Add(role);
        }

        public void UpdateRole(ApplicationRole role)
        {
            _context.Entry(role).State = EntityState.Modified;
        }


    }
}
