using HardcoreHistoryBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Data;

namespace HardcoreHistoryBlog.Core
{
    public class BloggerRepository : IBloggerRepository
    {
        private readonly BlogDbContext context;
        public BloggerRepository (BlogDbContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
        }

        bool Succeeded;
        public IEnumerable<Blogger> BloggerIEmum
        {
            get
            {
                return context.Bloggers;
            }
        }
        public IQueryable<Blogger> BloggerList

        {
            get
            {
                return context.Bloggers.AsQueryable();
            }
        }

        public bool Save(Blogger blogger)
        {
            if (blogger.BloggerId == 0)
            {
                Blogger _blogger = new Blogger();
                _blogger.FirstName = blogger.FirstName;
                _blogger.LastName = blogger.LastName;
                _blogger.Email = blogger.Email;

                _blogger.Password = blogger.Password;

                _blogger.Last_Login = blogger.Last_Login;
                _blogger.RoleId = blogger.RoleId;
                _blogger.AuthoredPosts = blogger.AuthoredPosts;
                _blogger.ContributedToPosts = blogger.ContributedToPosts;

                context.Bloggers.Add(_blogger);
                _blogger.BloggerId = blogger.BloggerId;

               int res = context.SaveChanges();

                if (res > 0)

                {
                    Succeeded = true;
                }
                else
                {
                    Succeeded = false;
                }

            }
            else
            {
                Blogger dbEntry = context.Bloggers.Find(blogger.BloggerId);
                if (dbEntry != null)
                {
                    dbEntry.BloggerId = blogger.BloggerId;
                    dbEntry.FirstName = blogger.FirstName;
                    dbEntry.LastName = blogger.LastName;
                    dbEntry.Email = blogger.Email;
                    dbEntry.Password = blogger.Password;
                    dbEntry.Last_Login = blogger.Last_Login;
                    dbEntry.RoleId = blogger.RoleId;
                    dbEntry.AuthoredPosts = blogger.AuthoredPosts;
                    dbEntry.ContributedToPosts = blogger.ContributedToPosts;
                }

                if (context.SaveChanges() > 0)
                {
                    Succeeded = true;
                }
                else
                {
                    Succeeded = false;
                }
                blogger.BloggerId = dbEntry.BloggerId;
            }
            return Succeeded;
        }
        public Blogger Details(int? Id)
        {
            Blogger dbEntry = context.Bloggers.Find(Id);
            return dbEntry;
                
        }
        public bool UniqueEmail(string email)
        {
            var result = true;
            var res = context.Users.FirstOrDefault(x => x.Email == email);
            if (res != null)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }



    }
}
