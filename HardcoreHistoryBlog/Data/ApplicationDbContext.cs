using System;
using System.Collections.Generic;
using System.Text;
using HardcoreHistoryBlog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HardcoreHistoryBlog.Data;

namespace HardcoreHistoryBlog.Data
{
    //public class ApplicationDbContext : IdentityDbContext<
    //    ApplicationUser>
    public class ApplicationDbContext : IdentityDbContext<
        ApplicationUser>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
            public DbSet<Client> Clients { get; set; }
            public DbSet<Customer> Customers { get; set; }
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
