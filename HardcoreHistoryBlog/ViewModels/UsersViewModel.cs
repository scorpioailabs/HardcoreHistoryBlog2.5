using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Data;

namespace HardcoreHistoryBlog.ViewModels
{
    public class UsersViewModel
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Second Name")]
        public string LastName { get; set; }

        public string Username { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
