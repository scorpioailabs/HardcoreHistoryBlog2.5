using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.Models.Blog_Models
{
    public class Settings
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Home Image is required")]
        [DisplayName("Home Image:")]
        public string HomeImage { get; set; }
        [Required(ErrorMessage = "Home Text is required")]
        [DisplayName("Home Text:")]
        [DataType(DataType.MultilineText)]
        public string HomeImageText { get; set; }
        [Required(ErrorMessage = "Number of Last Post is required")]
        [DisplayName("Number of Last Post:")]
        public int NumberOfLastPost { get; set; }
        [Required(ErrorMessage = "Num. of Category is required")]
        [DisplayName("Categories:")]
        public int Categories { get; set; } 
        [Required(ErrorMessage = "Post Number in Page is required")]
        [DisplayName("Post Num. in Page:")]
        public int PostNumberInPage { get; set; }
        [Required(ErrorMessage = "Number of Top Posts is required")]
        [DisplayName("Num. of Top Post:")]
        public int NumberOfTopPost { get; set; }

        [DisplayName("Last Update:")]
        public DateTime Update_Time { get; set; }
        [DisplayName("Updated By:")]
        public int UserId { get; set; }
        [DisplayName("Last Category")]
        public virtual Category LastTopic { get; set; }   
    }
}
