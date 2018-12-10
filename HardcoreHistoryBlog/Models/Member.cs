using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardcoreHistoryBlog.Models
{
    public class Member
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Second Name")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("UserName")]
        public string UserName { get; set; }        
    }
}
