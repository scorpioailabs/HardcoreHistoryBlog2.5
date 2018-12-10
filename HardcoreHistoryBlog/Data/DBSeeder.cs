using System;
using System.Linq;
using System.Threading.Tasks;
using HardcoreHistoryBlog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HardcoreHistoryBlog.Data
{
    public class DBSeeder
    {


        public static void SeedDb
            (ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();
            {
                ApplicationUser user = new ApplicationUser
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
                    "Blogger").Wait();
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
                        (user, "Member").Wait();
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
                        (user, "Member").Wait();
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
                                        "Member").Wait();
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
                                        "Member").Wait();
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
                                        "Member").Wait();
                }
            }

            if (!roleManager.RoleExistsAsync("Blogger").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Blogger"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync
                ("Admin").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync
                ("Member").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Member"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }

    }
}
