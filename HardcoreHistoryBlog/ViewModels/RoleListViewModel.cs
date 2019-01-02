using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.ViewModels
{
    public class RoleListViewModel 
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public int NumberOfUsers { get; set; }
    }
}
