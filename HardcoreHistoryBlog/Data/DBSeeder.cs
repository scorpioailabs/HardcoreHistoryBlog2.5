using System;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Models;
using HardcoreHistoryBlog.Models.Blog_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HardcoreHistoryBlog.Data
{
    public class DBSeeder
    {


        public static void SeedDb
            (ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            context.Database.Migrate();
            {
                

                if (!roleManager.RoleExistsAsync
                    ("Admin").Result)
                {
                    ApplicationRole role = new ApplicationRole
                    {
                        Name = "Admin"
                    };
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
                }

                if (!roleManager.RoleExistsAsync
                    ("Customer").Result)
                {
                    ApplicationRole role = new ApplicationRole
                    {
                        Name = "Customer"
                    };
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
                }
                Client user = new Client 
                {
                    UserName = "Member1@email.com",
                    Email = "Member1@email.com",
                    FirstName = "Member1",
                    LastName = "Member1"
                };

                IdentityResult result = userManager.CreateAsync
                (user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                    "Admin").Wait();
                }
            }


            if (userManager.FindByNameAsync
        ("Customer1").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "Customer1@email.com",
                    Email = "Customer1@email.com",
                    FirstName = "Customer1",
                    LastName = "Customer1"
                };

                IdentityResult result = userManager.CreateAsync
                (user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync
                        (user, "Customer").Wait();
                }
            }

            if (userManager.FindByNameAsync
        ("Customer2").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "Customer2@email.com",
                    Email = "Customer2@email.com",
                    FirstName = "Customer2",
                    LastName = "Customer2"
                };

                IdentityResult result = userManager.CreateAsync
                (user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync
                        (user, "Customer").Wait();
                }
            }

            if (userManager.FindByNameAsync
        ("Customer3").Result == null)
            {
                ApplicationUser user = new ApplicationUser 
                {
                    UserName = "Customer3@email.com",
                    Email = "Customer3@email.com",
                    FirstName = "Customer3",
                    LastName = "Customer3"
                };

                IdentityResult result = userManager.CreateAsync
                (user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Customer").Wait();
                }
            }

            if (userManager.FindByNameAsync
        ("Customer4").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "Customer4@email.com",
                    Email = "Customer4@email.com",
                    FirstName = "Customer4",
                    LastName = "Customer4"
                };

                IdentityResult result = userManager.CreateAsync
                (user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Customer").Wait();
                }
            }

            if (userManager.FindByNameAsync
        ("Customer5").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "Customer5@email.com",
                    Email = "Customer5@email.com",
                    FirstName = "Customer5",
                    LastName = "Customer5"
                };

                IdentityResult result = userManager.CreateAsync
                (user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Customer").Wait();
                }
            }

            if (!context.Posts.Any())
            {
                context.Posts.Add(new Post() { Title = "My first post", Short_Description = "Test post in Hardcore History", Content = "The Mongols- A short, bloody account.", Tag = "Mongols", Category = "Medieval History" });
                context.SaveChanges();
            }
            if(!context.Tags.Any())
            {
                context.Tags.Add(new Tag() { Name = "Mongols" });
                context.SaveChanges();
            }
            if(!context.Categories.Any())
            {
                context.Categories.Add(new Category() { Name = "Medieval History" });
                context.SaveChanges();
            }
        }

    }
}
