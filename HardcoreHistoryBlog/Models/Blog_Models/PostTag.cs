using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models.Blog_Models
{
    public class PostTag
    {
        [Key]
        public int PostId { get; set; }
        public Post Post { get; set; }  
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public string Name { get; set; }  
    }
}
