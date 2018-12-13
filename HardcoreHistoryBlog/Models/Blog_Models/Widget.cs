using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models.Blog_Models
{
    public class Widget
    {
        public int WidgetId { get; set; }
        [Required(ErrorMessage= "Name is required")]
        [DisplayName("Name:")]
        public string WidgetName { get; set; }

        [Required(ErrorMessage = "Content is required")]
        [DisplayName("Content")]
        [DataType(DataType.MultilineText)]
        public string WidgetContent { get; set; }

        [Required]
        [DisplayName("Updated on")]
        public DateTime Updated_On { get; set; }

        [DisplayName("Updated by")]
        public int AuthorId { get; set; }  

        public virtual Author AuthorDetails { get; set; }
        public virtual Contributor ContributorDetails { get; set; }
}
}
