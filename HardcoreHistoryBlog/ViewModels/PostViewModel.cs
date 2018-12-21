﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public virtual string Title { get; set; } = "";
        public virtual string Short_Description { get; set; } = "";
        public IFormFile Image { get; set; }

        [DataType(DataType.MultilineText)]
        public virtual string Content { get; set; } = "";
    }
}
