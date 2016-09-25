using zakjr_mag.Models;
using Microsoft.EntityFrameworkCore;

namespace zakjr_mag.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<BlogPost>().ToTable("BlogPost");
            modelBuilder.Entity<Comment>().ToTable("Comment");
        }
    }
}
