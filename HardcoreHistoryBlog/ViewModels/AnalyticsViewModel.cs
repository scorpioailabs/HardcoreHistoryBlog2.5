using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.ViewModels
{
    public class AnalyticsViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public int NumberOfComments { get; set; }
        public int NumberOfUsers { get; set; }
        public int PostId { get; set; }
    }
}
