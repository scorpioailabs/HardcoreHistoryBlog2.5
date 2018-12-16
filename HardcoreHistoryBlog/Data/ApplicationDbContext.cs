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
            public DbSet<PostTag> postTags { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Comment> Comments { get; set; }
            public DbSet<Settings> Settings { get; set; }
            public DbSet<Like> Likes { get; set; }
            public DbSet<Widget> Widgets { get; set; }
            public DbSet<Blogger> Bloggers { get; set; }
            public DbSet<Member> Members { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Comment>()
                .HasOne(pt => pt.Post)
                .WithMany(c => c.Comments)
                .HasForeignKey("FK_Comments_Posts_PostId")
                .OnDelete(DeleteBehavior.ClientSetNull); // sets null

            base.OnModelCreating(modelbuilder);
        }
        public DbSet<HardcoreHistoryBlog.Models.BlogViewModel> BlogViewModel { get; set; }
    }
}
