using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace zakjr.Data.Migrations
{
    public partial class BlogPostSplitContentChunkList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "BlogPosts");

            migrationBuilder.DropTable(
                name: "ContentChunks");

            migrationBuilder.CreateTable(
                name: "CodeContentChunks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlogPostID = table.Column<int>(nullable: false),
                    CodeLanguage = table.Column<string>(maxLength: 15, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeContentChunks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CodeContentChunks_BlogPosts_BlogPostID",
                        column: x => x.BlogPostID,
                        principalTable: "BlogPosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageContentChunks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlogPostID = table.Column<int>(nullable: false),
                    CanExpand = table.Column<bool>(nullable: false),
                    ImageAlt = table.Column<string>(nullable: false),
                    ImageCaption = table.Column<string>(maxLength: 150, nullable: true),
                    ImageUrl = table.Column<string>(nullable: false),
                    LoadingGradient = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageContentChunks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageContentChunks_BlogPosts_BlogPostID",
                        column: x => x.BlogPostID,
                        principalTable: "BlogPosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextContentChunks",
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
                    table.PrimaryKey("PK_TextContentChunks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TextContentChunks_BlogPosts_BlogPostID",
                        column: x => x.BlogPostID,
                        principalTable: "BlogPosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoContentChunks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlogPostID = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    VideoIsWidescreen = table.Column<bool>(nullable: false),
                    VideoUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoContentChunks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VideoContentChunks_BlogPosts_BlogPostID",
                        column: x => x.BlogPostID,
                        principalTable: "BlogPosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodeContentChunks_BlogPostID",
                table: "CodeContentChunks",
                column: "BlogPostID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageContentChunks_BlogPostID",
                table: "ImageContentChunks",
                column: "BlogPostID");

            migrationBuilder.CreateIndex(
                name: "IX_TextContentChunks_BlogPostID",
                table: "TextContentChunks",
                column: "BlogPostID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoContentChunks_BlogPostID",
                table: "VideoContentChunks",
                column: "BlogPostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeContentChunks");

            migrationBuilder.DropTable(
                name: "ImageContentChunks");

            migrationBuilder.DropTable(
                name: "TextContentChunks");

            migrationBuilder.DropTable(
                name: "VideoContentChunks");

            migrationBuilder.CreateTable(
                name: "ContentChunks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlogPostID = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    BlogPostID1 = table.Column<int>(nullable: true),
                    CodeLanguage = table.Column<string>(maxLength: 15, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CanExpand = table.Column<bool>(nullable: true),
                    ImageAlt = table.Column<string>(nullable: true),
                    ImageCaption = table.Column<string>(maxLength: 150, nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    LoadingGradient = table.Column<string>(nullable: true),
                    VideoIsWidescreen = table.Column<bool>(nullable: true),
                    VideoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentChunk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContentChunk_BlogPosts_BlogPostID1",
                        column: x => x.BlogPostID1,
                        principalTable: "BlogPosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContentChunk_BlogPosts_BlogPostID",
                        column: x => x.BlogPostID,
                        principalTable: "BlogPosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentChunk_BlogPosts_BlogPostID1",
                        column: x => x.BlogPostID1,
                        principalTable: "BlogPosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContentChunk_BlogPosts_BlogPostID1",
                        column: x => x.BlogPostID1,
                        principalTable: "BlogPosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContentChunk_BlogPosts_BlogPostID1",
                        column: x => x.BlogPostID1,
                        principalTable: "BlogPosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "BlogPosts",
                maxLength: 800,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentChunk_BlogPostID",
                table: "ContentChunk",
                column: "BlogPostID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentChunk_BlogPostID1",
                table: "ContentChunk",
                column: "BlogPostID1");
        }
    }
}
