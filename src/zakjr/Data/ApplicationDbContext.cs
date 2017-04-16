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
        public DbSet<TextContentChunk> TextContentChunks { get; set; }
        public DbSet<CodeContentChunk> CodeContentChunks { get; set; }
        public DbSet<ImageContentChunk> ImageContentChunks { get; set; }
        public DbSet<VideoContentChunk> VideoContentChunks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
