using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Core;
using HardcoreHistoryBlog.Data;
using HardcoreHistoryBlog.Models.Blog_Models;
using HardcoreHistoryBlog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using PagedList;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HardcoreHistoryBlog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IRepository _repo;
        private IFileManager _fileManager;
        private ApplicationDbContext _context;

        public PanelController(
            IFileManager fileManager,
            IRepository repo,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context
            ) 
        {
            _fileManager = fileManager;
            _repo = repo;
            _userManager = userManager;
            _context = context;
        }

        [Authorize(Roles ="Admin")]

        [AutoValidateAntiforgeryToken]
        public IActionResult Index()
        {
            var posts = _repo.GetAllPosts();
            return View(posts);
        }

        [AutoValidateAntiforgeryToken]
        public IActionResult Post(int id)
        {
            var post = _repo.GetPost(id);
            return View(post);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _repo.GetPost((int)id);
            return View(new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Short_Description = post.Short_Description,
                CurrentImage = post.Image,
                Content = post.Content,
                Category = post.Category,
                Tags = post.Tags
            });
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            var post = new Post
            {
                Id = vm.Id,
                Title = vm.Title,
                Content = vm.Content,
                Short_Description = vm.Short_Description,
                Category = vm.Category,
                Tags = vm.Tags
            };

            if (vm.Image == null)
                post.Image = vm.CurrentImage;
            else
                post.Image = await _fileManager.SaveImage(vm.Image);

            _repo.UpdatePost(post);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()

        {
            return View(new PostViewModel());
        }              
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel vm)
        {
            var post = new Post
            {
                Id = vm.Id,
                Title = vm.Title,
                Content = vm.Content,
                Short_Description = vm.Short_Description,
                Category = vm.Category,
                Tags = vm.Tags, 
                Image = await _fileManager.SaveImage(vm.Image)

            };
            _repo.AddPost(post);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(post);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePost((int)id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [AutoValidateAntiforgeryToken]
        public IActionResult Customers()    
        {
            return View();
        }

        [AutoValidateAntiforgeryToken]
        public IActionResult Admins()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View(new UsersViewModel());
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateUser(UsersViewModel vm)   
        {
            if (!ModelState.IsValid) return View(vm);
            {

                var user = new ApplicationUser { UserName = vm.Email, Email = vm.Email, FirstName = vm.FirstName, LastName = vm.LastName };
                var result = await _userManager.CreateAsync(user, vm.Password);
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Customer").Wait();
                    _repo.AddUser(user);
                    return RedirectToAction("Index", "Panel");
                }
                else
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult EditUser(string Id)
        {
            var user = _repo.GetUser((string)Id);
            return View(new UsersViewModel
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName
            });
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> EditUser(UsersViewModel vm) 
        {
            var user = await _userManager.FindByIdAsync(vm.UserId);

            if (vm.FirstName != user.FirstName)
            {
                user.FirstName = vm.FirstName;
            }
            if (vm.LastName != user.LastName)
            {
                user.LastName = vm.LastName;
            }
            if (vm.Username != user.UserName)
            {
                user.UserName = vm.Username;
            }
            if (vm.Email != user.Email) 
            {
                user.Email = vm.Email;
            }


            var result = _userManager.UpdateAsync(user).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Customers", "Panel");
            }
            else return View(vm);           
        }

        [AutoValidateAntiforgeryToken]
        public IActionResult UserDetails(string Id)
        {
            var user = _repo.GetUser((string)Id);
            return View(new UsersViewModel
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName
            });
        }

        public IActionResult Analytics()
        {
            List<AnalyticsViewModel> model = new List<AnalyticsViewModel>();
            model = _context.Posts.Select(p => new AnalyticsViewModel
            {
                Id = p.Id,
                Title = p.Title,
                NumberOfComments = p.MainComments.Count
            }).ToList();
            return View(model);
        }

        public IActionResult UserComments() 
        {
            List<AnalyticsViewModel> model = new List<AnalyticsViewModel>();
            model = _context.Users.Select(u => new AnalyticsViewModel
            {
                Username = u.UserName,
                UserId = u.Id,
                NumberOfComments = u.Comments.Count
            }).ToList();
            return View(model);
        }


    }
}