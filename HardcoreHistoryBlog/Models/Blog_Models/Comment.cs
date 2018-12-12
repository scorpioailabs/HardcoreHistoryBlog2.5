using HardcoreHistoryBlog.Models.Blog_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Required]
        [DisplayName("Comment:")]
        public string Content { get; set; }
        [DisplayName("Commented On:")]
        [Column(TypeName = "DateTime2")]
        public virtual DateTime CommentedOn { get; set; } 
        [DisplayName("Last updated:")]
        [Column(TypeName = "DateTime2")]
        public virtual DateTime? Modified { get; set; }
        public Nullable<DateTime> Update_time { get; set; }
        public int MemberId { get; set; }  
        public int PostForeignKey { get; set; }
        [ForeignKey("PostForeignKey")]
        public Post Post { get; set; }
        [DisplayName("Published")]
        public bool Publish { get; set; }

        virtual public Member MemberDetails { get; set; }
        
        public List<Like> Likes { get; set; }        
    }
}
