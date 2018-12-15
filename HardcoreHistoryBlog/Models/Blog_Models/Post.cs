using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Title is required")]

        public virtual string Short_Description { get; set; }
        public virtual string Content { get; set; } 

        [ForeignKey("AuthorForeignKey")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        [ForeignKey("BloggerForeignKey")]
        public int ContributorBloggerId { get; set; }
        public Contributor Contributor { get; set; }

        public virtual bool Published { get; set; }

        [DisplayName("Posted On")]
        public virtual DateTime PostedOn { get; set; }

        [DisplayName("Updated On")]
        public virtual DateTime? Modified { get; set; }

        [Required(ErrorMessage = "At least one Category is required")]
        [DisplayName("Category:")]
        public int CategoryId { get; set; }

        internal void SaveChanges()
        {
            throw new Exception();
        }

        internal void AddToPosts(Post post)
        {
            AddToPosts(post);
        }

        public int GetPost { get; set; } 

        public virtual Category Category { get; set; }

        [Required(ErrorMessage = "Tag is required")]
        [DisplayName("Tags:")]
        public List<PostTag> postTags { get; set; } 
        public List<Comment> Comments { get; set; }

        public int BlogForeignKey { get; set; }
        [ForeignKey("BlogForeignKey")]
        public Blog Blog { get; set; }

        public List<Like> Likes { get; set; }
        public virtual IEnumerable<Category> GetCategories { get; set; }

    }
    public class Author

    {
        [ForeignKey("BloggerForeignKey")]
        public int Id { get; set; }  
        public virtual Blogger Blogger { get; set; }
    }
    public class Contributor
    {
        [ForeignKey("BloggerForeignKey")]
        public int Id { get; set; }  
        public virtual Blogger Blogger { get; set; }
    }
}
