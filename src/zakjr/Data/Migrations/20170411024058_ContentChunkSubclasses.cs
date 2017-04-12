using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace zakjr.Data.Migrations
{
    public partial class ContentChunkSubclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPost_Category_CategoryID",
                table: "BlogPost");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_BlogPost_BlogPostID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Comment_CommentID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentChunk_BlogPost_BlogPostID",
                table: "ContentChunk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentChunk",
                table: "ContentChunk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPost",
                table: "BlogPost");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ContentChunk",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodeLanguage",
                table: "ContentChunk",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CanExpand",
                table: "ContentChunk",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageAlt",
                table: "ContentChunk",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageCaption",
                table: "ContentChunk",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ContentChunk",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoadingGradient",
                table: "ContentChunk",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VideoIsWidescreen",
                table: "ContentChunk",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "ContentChunk",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentChunks",
                table: "ContentChunk",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comment",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Category",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPost",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Categories_CategoryID",
                table: "BlogPost",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostID",
                table: "Comment",
                column: "BlogPostID",
                principalTable: "BlogPost",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentID",
                table: "Comment",
                column: "CommentID",
                principalTable: "Comment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentChunks_BlogPosts_BlogPostID",
                table: "ContentChunk",
                column: "BlogPostID",
                principalTable: "BlogPost",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_ContentChunk_BlogPostID",
                table: "ContentChunk",
                newName: "IX_ContentChunks_BlogPostID");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_CommentID",
                table: "Comment",
                newName: "IX_Comments_CommentID");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_BlogPostID",
                table: "Comment",
                newName: "IX_Comments_BlogPostID");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPost_CategoryID",
                table: "BlogPost",
                newName: "IX_BlogPosts_CategoryID");

            migrationBuilder.RenameTable(
                name: "ContentChunk",
                newName: "ContentChunks");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "BlogPost",
                newName: "BlogPosts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Categories_CategoryID",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentChunks_BlogPosts_BlogPostID",
                table: "ContentChunks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentChunks",
                table: "ContentChunks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ContentChunks");

            migrationBuilder.DropColumn(
                name: "CodeLanguage",
                table: "ContentChunks");

            migrationBuilder.DropColumn(
                name: "CanExpand",
                table: "ContentChunks");

            migrationBuilder.DropColumn(
                name: "ImageAlt",
                table: "ContentChunks");

            migrationBuilder.DropColumn(
                name: "ImageCaption",
                table: "ContentChunks");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ContentChunks");

            migrationBuilder.DropColumn(
                name: "LoadingGradient",
                table: "ContentChunks");

            migrationBuilder.DropColumn(
                name: "VideoIsWidescreen",
                table: "ContentChunks");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "ContentChunks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentChunk",
                table: "ContentChunks",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comments",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Categories",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPost",
                table: "BlogPosts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPost_Category_CategoryID",
                table: "BlogPosts",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_BlogPost_BlogPostID",
                table: "Comments",
                column: "BlogPostID",
                principalTable: "BlogPosts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Comment_CommentID",
                table: "Comments",
                column: "CommentID",
                principalTable: "Comments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentChunk_BlogPost_BlogPostID",
                table: "ContentChunks",
                column: "BlogPostID",
                principalTable: "BlogPosts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_ContentChunks_BlogPostID",
                table: "ContentChunks",
                newName: "IX_ContentChunk_BlogPostID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentID",
                table: "Comments",
                newName: "IX_Comment_CommentID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BlogPostID",
                table: "Comments",
                newName: "IX_Comment_BlogPostID");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPosts_CategoryID",
                table: "BlogPosts",
                newName: "IX_BlogPost_CategoryID");

            migrationBuilder.RenameTable(
                name: "ContentChunks",
                newName: "ContentChunk");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "BlogPosts",
                newName: "BlogPost");
        }
    }
}
