using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models
{
    public class DashboardVM
    {
        public Blogger Blogger { get; set; }
        public int NumberOfNewPosts { get; set; }
        public int NumberOfUnapprovedComments { get; set; }
    }
}
