using HardcoreHistoryBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Core
{
    public interface IMemberRepository
    {
        bool Save(Member member);
        Member Details(int? Id);
        IEnumerable<Member> BloggerIEmum { get; }
        IQueryable<Member> BloggerList { get; }

        bool UniqueEmail(string email);
    }
}
