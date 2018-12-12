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
        private readonly BlogDbContext context;
        public MemberRepository(BlogDbContext context)
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
            if (member.MemberId == 0)
            {
                Member _member = new Member();
                _member.FirstName = member.FirstName;
                _member.LastName = member.LastName;
                _member.Email = member.Email;

                _member.Password = member.Password;

                _member.Last_Login = member.Last_Login;
                _member.RoleId = member.RoleId;
                _member.CommentedOnPosts = member.CommentedOnPosts;

                context.Members.Add(_member);
                _member.MemberId = member.MemberId;

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
                Member dbEntry = context.Members.Find(member.MemberId);
                if (dbEntry != null)
                {
                    dbEntry.MemberId = member.MemberId;
                    dbEntry.FirstName = member.FirstName;
                    dbEntry.LastName = member.LastName;
                    dbEntry.Email = member.Email;
                    dbEntry.Password = member.Password;
                    dbEntry.Last_Login = member.Last_Login;
                    dbEntry.RoleId = member.RoleId;
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
                member.MemberId = dbEntry.MemberId;
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
