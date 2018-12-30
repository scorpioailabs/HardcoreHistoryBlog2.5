using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.ViewModels
{
    public class RoleViewModel
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
