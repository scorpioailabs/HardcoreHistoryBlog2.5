using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Core
{
    public class MemberRepository
    {
        private readonly ApplicationDbContext context;
        public MemberRepository(ApplicationDbContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
        }
        bool Succeeded;
        public IEnumerable<Member> MemberIEmum
        {
            get
            {
                return context.Members;
            }
        }
        public IQueryable<Member> MemberList

        {
            get
            {
                return context.Members.AsQueryable();
            }
        }

        public bool Save(Member member)
        {
            if (member.Id == null)
            {
                Member _member = new Member
                {
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Email = member.Email,

                    PasswordHash = member.PasswordHash,

                    CommentedOnPosts = member.CommentedOnPosts
                };

                context.Members.Add(_member);
                _member.Id = member.Id;

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
                Member dbEntry = context.Members.Find(member.Id);
                if (dbEntry != null)
                {
                    dbEntry.Id = member.Id;
                    dbEntry.FirstName = member.FirstName;
                    dbEntry.LastName = member.LastName;
                    dbEntry.Email = member.Email;
                    dbEntry.PasswordHash = member.PasswordHash;
                    dbEntry.CommentedOnPosts = member.CommentedOnPosts;
                }

                if (context.SaveChanges() > 0)
                {
                    Succeeded = true;
                }
                else
                {
                    Succeeded = false;
                }
                member.Id = dbEntry.Id;
            }
            return Succeeded;
        }
        public Member Details(int? Id)
        {
            Member dbEntry = context.Members.Find(Id);
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
