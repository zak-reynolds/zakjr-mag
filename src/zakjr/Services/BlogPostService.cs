using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using zakjr.Data;
using zakjr.Models;
using zakjr.ViewModels;

namespace zakjr.Services
{
    public class BlogPostService : IBlogPostService
    {

        private ApplicationDbContext _context { get; }

        public BlogPostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public BlogPostViewModel GetBlogPost(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BlogPostViewModel> GetBlogPostAsync(int id)
        {
            var result = new BlogPostViewModel();
            result.ThePost = await _context.BlogPosts.FirstOrDefaultAsync(bp => bp.ID == id);
            result.ThePost.ContentList = await _context.ContentChunks.Where(cc => cc.BlogPostID == id).ToListAsync();
            result.ThePost.ContentList.Sort((a, b) => a.Sequence.CompareTo(b.Sequence));

            result.TheComments = new CommentSection()
            {
                HeaderText = "Comments",
                CommentList = await _context.Comments.Where(c => c.BlogPostID == id).Include(c => c.Comments).ToListAsync()
            };
            result.TheCover = new BlogPostCover()
            {
                CoverImage = result.ThePost.FeaturedImage,
                Title = result.ThePost.Title,
                TagLine = result.ThePost.Subtitle
            };

            // TODO: This more elegantly
            Category postCategory = await _context.Categories.FirstOrDefaultAsync(cat => cat.ID == result.ThePost.CategoryID);
            result.TheNavigation = new List<NavItem>()
            {
                new NavItem()
                {
                    Url = "/blog",
                    DisplayText = "Home"
                },
                new NavItem()
                {
                    Url = "/blog/categories/" + postCategory.ID,
                    DisplayText = postCategory.Name
                },
                new NavItem()
                {
                    Url = "/blog/post/" + result.ThePost.ID,
                    DisplayText = result.ThePost.Title
                }
            };
            
            return result;
        }

        public CategoryViewModel GetBlogPostsInCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryViewModel> GetBlogPostsInCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public RecentPostsByCategoryViewModel GetRecentPostsByCategory()
        {
            throw new NotImplementedException();
        }

        public async Task<RecentPostsByCategoryViewModel> GetRecentPostsByCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public void CreateBlogPost(BlogPost newPost)
        {
            newPost.PostDate = DateTime.Now;
            _context.Add(newPost);
            _context.SaveChanges();
        }

        public async Task CreateBlogPostAsync(BlogPost newPost)
        {
            newPost.PostDate = DateTime.Now;
            _context.Add(newPost);
            await _context.SaveChangesAsync();
        }
        public async Task AddTextContentChunk(TextContentChunk theChunk)
        {
            _context.Add(theChunk);
            await _context.SaveChangesAsync();
        }

        public async Task AddTextContentChunkAsync(TextContentChunk theChunk)
        {
            _context.Add(theChunk);
            await _context.SaveChangesAsync();
        }

        public async Task AddImageContentChunkAsync(ImageContentChunk theChunk)
        {
            _context.Add(theChunk);
            await _context.SaveChangesAsync();
        }

        public async Task AddCodeContentChunkAsync(CodeContentChunk theChunk)
        {
            _context.Add(theChunk);
            await _context.SaveChangesAsync();
        }

        public async Task AddVideoContentChunkAsync(VideoContentChunk theChunk)
        {
            _context.Add(theChunk);
            await _context.SaveChangesAsync();
        }
    }
}
