using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HardcoreHistoryBlog.ViewModels
{
    public class LikeViewModel
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        public int PostLikeId { get; set; }
    }
}
