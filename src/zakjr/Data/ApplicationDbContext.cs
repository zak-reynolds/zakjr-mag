using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using zakjr.Models;

namespace zakjr.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<ContentChunk> ContentChunks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Category");
            builder.Entity<BlogPost>().ToTable("BlogPost");
            builder.Entity<ContentChunk>().ToTable("ContentChunk");
            builder.Entity<Comment>().ToTable("Comment");
        }
    }
}
