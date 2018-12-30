using System;
using System.Collections.Generic;
using System.Text;
using HardcoreHistoryBlog.Models;
using HardcoreHistoryBlog.Models.Blog_Models;
using HardcoreHistoryBlog.Models.Comments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HardcoreHistoryBlog.ViewModels;

namespace HardcoreHistoryBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext<
                ApplicationUser, ApplicationRole, string,
        IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>

    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
            public DbSet<Post> Posts { get; set; }
            public DbSet<MainComment> MainComments { get; set; }
            public DbSet<SubComment> SubComments { get; set; } 
            public DbSet<HardcoreHistoryBlog.Models.RegisterViewModel> RegisterViewModel { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }


        public DbSet<HardcoreHistoryBlog.ViewModels.UsersViewModel> UsersViewModel { get; set; }


        public DbSet<HardcoreHistoryBlog.ViewModels.RoleViewModel> RoleViewModel { get; set; }
    }
}
