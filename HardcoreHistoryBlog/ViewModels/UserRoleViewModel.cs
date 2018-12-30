using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.ViewModels
{
    public class UserRoleViewModel
    {
        public List<int> SelectedRoleIds { get; set; }

        public IEnumerable<SelectListItem> RoleChoices { get; set; }

    }
}
