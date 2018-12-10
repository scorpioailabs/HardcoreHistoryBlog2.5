using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Data;

namespace HardcoreHistoryBlog.Models.Blog_Models
{
    public class Tag
    {
        public virtual int TagId { get; set; }        
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
}
