using HardcoreHistoryBlog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Core
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        bool Succeeded;

        public IEnumerable<ApplicationUser> UserIEmum
        {
            get
            {
                return _context.Users;
            }
        }

        public IQueryable<ApplicationUser> UserList
        {
            get
            {
                return _context.Users.AsQueryable();
            }
        }

        public bool Save(ApplicationUser user)
        {
            if (user.Id == null)
            {
                ApplicationUser _user = new ApplicationUser();
                _user.FirstName = user.FirstName;
                _user.LastName = user.LastName;
                _user.Email = user.Email;
                _user.PasswordHash = user.PasswordHash;

                _user.UserRoles = user.UserRoles;
                _context.Users.Add(_user);
                user.Id = _user.Id;

                int res = _context.SaveChanges();

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
                ApplicationUser dbEntry = _context.Users.Find(user.Id);
                if (dbEntry != null)
                {
                    dbEntry.Id = user.Id;
                    dbEntry.FirstName = user.FirstName;
                    dbEntry.LastName = user.LastName;
                    dbEntry.PasswordHash = user.PasswordHash;
                    dbEntry.UserRoles = user.UserRoles;

                    if (_context.SaveChanges() > 0)
                    {
                        Succeeded = true;
                    }
                    else
                    {
                        Succeeded = false;
                    }
                    user.Id = dbEntry.Id;
                }
            }
            return Succeeded;
        }


        public ApplicationUser Details(int? Id)
        {
            ApplicationUser dbEntry = _context.Users.Find(Id);
            return dbEntry;
        }


        public ApplicationUser Delete(int? Id)
        {
            ApplicationUser dbEntry = _context.Users.Find(Id);
            if (dbEntry != null)
            {
                _context.Users.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }




        public bool UniqueEmail(string email)
        {
            var result = true;
            var res = _context.Users.FirstOrDefault(x => x.Email == email);
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
