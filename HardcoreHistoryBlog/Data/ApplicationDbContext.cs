using System;
using System.Collections.Generic;
using System.Text;
using HardcoreHistoryBlog.Models;
using HardcoreHistoryBlog.Models.Blog_Models;
using HardcoreHistoryBlog.Models.Comments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HardcoreHistoryBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext<
                ApplicationUser, ApplicationRole, string,
        IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>

    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
            public DbSet<Post> Posts { get; set; }
            public DbSet<MainComment> MainComments { get; set; }
            public DbSet<SubComment> SubComments { get; set; } 
            

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Comment>()
        //        .HasOne(pt => pt.Post)
        //        .WithMany(c => c.Comments)
        //        .HasForeignKey("FK_Comments_Posts_id")
        //        .OnDelete(DeleteBehavior.ClientSetNull); // sets null

        //    base.OnModelCreating(builder);

        //    builder.Entity<ApplicationUser>(b =>
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
        //            .WithOne()
        //            .HasForeignKey(ur => ur.UserId)
        //            .IsRequired();
        //    });

        //    {
        //        builder.Entity<Post>().ToTable("Posts");
        //        builder.Entity<Comment>().ToTable("Comments");
        //    }
        //}
    }
}
