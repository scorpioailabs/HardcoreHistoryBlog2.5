using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Data;

namespace HardcoreHistoryBlog.Models.Blog_Models
{
    public class Post
    {
        public virtual int PostId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Short_Description { get; set; }
        public virtual string Description { get; set; }

        public int AuthorId { get; set; }
        public Blogger Author { get; set; }

        public int ContributorBloggerId { get; set; }
        public Blogger Contributer { get; set; }

        public virtual string Meta { get; set; }
        public virtual bool Published { get; set; }
        public virtual DateTime PostedOn { get; set; }
        public virtual  DateTime? Modified { get; set; }
        
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual IList<Tag> Tags { get; set; }

        public int BlogForeignKey { get; set; }
        [ForeignKey("BlogForeignKey")]
        public Blog Blog { get; set; }
    }
}
