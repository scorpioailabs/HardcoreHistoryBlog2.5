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
        private readonly ApplicationDbContext context;
        public BloggerRepository (ApplicationDbContext context)
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
            if (blogger.Id == null )
            {
                Blogger _blogger = new Blogger
                {
                    FirstName = blogger.FirstName,
                    LastName = blogger.LastName,
                    Email = blogger.Email,

                    PasswordHash = blogger.PasswordHash,

                    AuthoredPosts = blogger.AuthoredPosts,
                    ContributedToPosts = blogger.ContributedToPosts
                };

                context.Bloggers.Add(_blogger);
                _blogger.Id = blogger.Id;

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
                Blogger dbEntry = context.Bloggers.Find(blogger.Id);
                if (dbEntry != null)
                {
                    dbEntry.Id = blogger.Id;
                    dbEntry.FirstName = blogger.FirstName;
                    dbEntry.LastName = blogger.LastName;
                    dbEntry.Email = blogger.Email;
                    dbEntry.PasswordHash = blogger.PasswordHash;
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
                blogger.Id = dbEntry.Id;
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
