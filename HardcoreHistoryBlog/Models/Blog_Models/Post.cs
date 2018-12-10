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
        public Blogger Contributor { get; set; }

        public virtual bool Published { get; set; }
        public virtual DateTime PostedOn { get; set; }
        public virtual DateTime? Modified { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public List<PostTag> PostTags { get; set; }
        public List<Comment> Comments { get; set; }

        public int BlogForeignKey { get; set; }
        [ForeignKey("BlogForeignKey")]
        public Blog Blog { get; set; }

        public List<Like> Likes { get; set; }
    }
    public class Author
    {
        public int AuthorBloggerId { get; set; }
        public virtual Blogger Blogger { get; set; }

    }
    public class Contributor
    {
        public int ContributorBloggerId { get; set; }
        public virtual Blogger Blogger { get; set; }
    }
}
