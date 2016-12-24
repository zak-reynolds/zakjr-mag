using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace zakjrmag.Migrations
{
    public partial class BlogPostChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Tagline = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BlogPost",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    FeaturedImage = table.Column<string>(nullable: true),
                    PostDate = table.Column<DateTime>(nullable: false),
                    Subtitle = table.Column<string>(maxLength: 60, nullable: true),
                    Title = table.Column<string>(maxLength: 60, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPost", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BlogPost_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(nullable: true),
                    BlogPostID = table.Column<int>(nullable: false),
                    CommentID = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    PostDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_BlogPost_BlogPostID",
                        column: x => x.BlogPostID,
                        principalTable: "BlogPost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_CommentID",
                        column: x => x.CommentID,
                        principalTable: "Comment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentChunk",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlogPostID = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentChunk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContentChunk_BlogPost_BlogPostID",
                        column: x => x.BlogPostID,
                        principalTable: "BlogPost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPost_CategoryID",
                table: "BlogPost",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_BlogPostID",
                table: "Comment",
                column: "BlogPostID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommentID",
                table: "Comment",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentChunk_BlogPostID",
                table: "ContentChunk",
                column: "BlogPostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "ContentChunk");

            migrationBuilder.DropTable(
                name: "BlogPost");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
