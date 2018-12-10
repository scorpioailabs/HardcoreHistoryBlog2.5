using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.Core;
using HardcoreHistoryBlog.Models;
using HardcoreHistoryBlog.Models.Blog_Models;

namespace HardcoreHistoryBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository; 

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

    }
}