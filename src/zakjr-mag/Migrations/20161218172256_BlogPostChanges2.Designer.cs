using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using zakjr_mag.Data;

namespace zakjrmag.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20161218172256_BlogPostChanges2")]
    partial class BlogPostChanges2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("zakjr_mag.Models.BlogPost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryID");

                    b.Property<string>("Content");

                    b.Property<string>("FeaturedImage");

                    b.Property<DateTime>("PostDate");

                    b.Property<string>("Subtitle")
                        .HasAnnotation("MaxLength", 60);

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 60);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("BlogPost");
                });

            modelBuilder.Entity("zakjr_mag.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Tagline");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("zakjr_mag.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<int>("BlogPostID");

                    b.Property<int?>("CommentID");

                    b.Property<string>("Content");

                    b.Property<DateTime>("PostDate");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("ID");

                    b.HasIndex("BlogPostID");

                    b.HasIndex("CommentID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("zakjr_mag.Models.ContentChunk", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogPostID");

                    b.Property<string>("Content");

                    b.Property<int>("Sequence");

                    b.HasKey("ID");

                    b.HasIndex("BlogPostID");

                    b.ToTable("ContentChunk");
                });

            modelBuilder.Entity("zakjr_mag.Models.BlogPost", b =>
                {
                    b.HasOne("zakjr_mag.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");
                });

            modelBuilder.Entity("zakjr_mag.Models.Comment", b =>
                {
                    b.HasOne("zakjr_mag.Models.BlogPost")
                        .WithMany("Comments")
                        .HasForeignKey("BlogPostID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("zakjr_mag.Models.Comment")
                        .WithMany("Comments")
                        .HasForeignKey("CommentID");
                });

            modelBuilder.Entity("zakjr_mag.Models.ContentChunk", b =>
                {
                    b.HasOne("zakjr_mag.Models.BlogPost", "BlogPost")
                        .WithMany("ContentList")
                        .HasForeignKey("BlogPostID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
