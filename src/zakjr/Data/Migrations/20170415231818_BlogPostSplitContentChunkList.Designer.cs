using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using zakjr.Data;

namespace zakjr.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170415231818_BlogPostSplitContentChunkList")]
    partial class BlogPostSplitContentChunkList
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("zakjr.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("zakjr.Models.BlogPost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryID");

                    b.Property<string>("FeaturedImage");

                    b.Property<DateTime>("PostDate");

                    b.Property<string>("Subtitle")
                        .HasAnnotation("MaxLength", 60);

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 60);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("zakjr.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Tagline");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("zakjr.Models.CodeContentChunk", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogPostID");

                    b.Property<string>("CodeLanguage")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("Content");

                    b.Property<int>("Sequence");

                    b.HasKey("ID");

                    b.HasIndex("BlogPostID");

                    b.ToTable("CodeContentChunks");
                });

            modelBuilder.Entity("zakjr.Models.Comment", b =>
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

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("zakjr.Models.ImageContentChunk", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogPostID");

                    b.Property<bool>("CanExpand");

                    b.Property<string>("ImageAlt")
                        .IsRequired();

                    b.Property<string>("ImageCaption")
                        .HasAnnotation("MaxLength", 150);

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<string>("LoadingGradient");

                    b.Property<int>("Sequence");

                    b.HasKey("ID");

                    b.HasIndex("BlogPostID");

                    b.ToTable("ImageContentChunks");
                });

            modelBuilder.Entity("zakjr.Models.TextContentChunk", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogPostID");

                    b.Property<string>("Content");

                    b.Property<int>("Sequence");

                    b.HasKey("ID");

                    b.HasIndex("BlogPostID");

                    b.ToTable("TextContentChunks");
                });

            modelBuilder.Entity("zakjr.Models.VideoContentChunk", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogPostID");

                    b.Property<int>("Sequence");

                    b.Property<bool>("VideoIsWidescreen");

                    b.Property<string>("VideoUrl")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("BlogPostID");

                    b.ToTable("VideoContentChunks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("zakjr.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("zakjr.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("zakjr.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("zakjr.Models.BlogPost", b =>
                {
                    b.HasOne("zakjr.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");
                });

            modelBuilder.Entity("zakjr.Models.CodeContentChunk", b =>
                {
                    b.HasOne("zakjr.Models.BlogPost", "BlogPost")
                        .WithMany("CodeContentList")
                        .HasForeignKey("BlogPostID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("zakjr.Models.Comment", b =>
                {
                    b.HasOne("zakjr.Models.BlogPost", "BlogPost")
                        .WithMany("Comments")
                        .HasForeignKey("BlogPostID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("zakjr.Models.Comment")
                        .WithMany("Comments")
                        .HasForeignKey("CommentID");
                });

            modelBuilder.Entity("zakjr.Models.ImageContentChunk", b =>
                {
                    b.HasOne("zakjr.Models.BlogPost", "BlogPost")
                        .WithMany("ImageContentList")
                        .HasForeignKey("BlogPostID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("zakjr.Models.TextContentChunk", b =>
                {
                    b.HasOne("zakjr.Models.BlogPost", "BlogPost")
                        .WithMany("TextContentList")
                        .HasForeignKey("BlogPostID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("zakjr.Models.VideoContentChunk", b =>
                {
                    b.HasOne("zakjr.Models.BlogPost", "BlogPost")
                        .WithMany("VideoContentList")
                        .HasForeignKey("BlogPostID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
