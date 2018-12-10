using System;
using System.Collections.Generic;
using System.Text;
using HardcoreHistoryBlog.Models;
using HardcoreHistoryBlog.Models.Blog_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HardcoreHistoryBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext<
        ApplicationUser>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }
            public DbSet<Tag> Tags { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Comment> Comments { get; set; }
            public DbSet<Like> Likes { get; set; }
            public DbSet<Blogger> Bloggers { get; set; }
            public DbSet<Client> Clients { get; set; }
            public DbSet<Member> Customers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<ApplicationUser>(b =>
        //    {
        //        // Each User can have many UserClaims
        //        b.HasMany(e => e.Claims)
        //            .WithOne()
        //            .HasForeignKey(uc => uc.UserId)
        //            .IsRequired();

        //        // Each User can have many UserLogins
        //        b.HasMany(e => e.Logins)
        //            .WithOne()
        //            .HasForeignKey(ul => ul.UserId)
        //            .IsRequired();

        //        // Each User can have many UserTokens
        //        b.HasMany(e => e.Tokens)
        //            .WithOne()
        //            .HasForeignKey(ut => ut.UserId)
        //            .IsRequired();

        //        // Each User can have many entries in the UserRole join table
        //        b.HasMany(e => e.UserRoles)
        //            .WithOne(e => e.User)
        //            .HasForeignKey(ur => ur.UserId)
        //            .IsRequired();
        //    });

            //modelBuilder.Entity<IdentityRole>(b =>
            //{
            //    // Each Role can have many entries in the UserRole join table
            //    b.HasMany(e => e.UserRoles)
            //        .WithOne(e => e.Role)
            //        .HasForeignKey(ur => ur.RoleId)
            //        .IsRequired();
            //});

        //}
    }
}
