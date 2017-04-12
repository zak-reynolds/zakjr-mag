using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zakjr.Models;
using zakjr.ViewModels;

namespace zakjr.Services
{
    public interface IBlogPostService
    {
        /// <summary>
        /// Collects the most recent post in each category.
        /// </summary>
        /// <returns>ViewModel containing one (most recent) post from every category.</returns>
        RecentPostsByCategoryViewModel GetRecentPostsByCategory();
        /// <summary>
        /// Collects the most recent post in each category.
        /// </summary>
        /// <returns>ViewModel containing one (most recent) post from every category.</returns>
        Task<RecentPostsByCategoryViewModel> GetRecentPostsByCategoryAsync();

        /// <summary>
        /// Gets the post with the given ID.
        /// </summary>
        /// <returns>ViewModel containing one post.</returns>
        BlogPostViewModel GetBlogPost(int id);
        /// <summary>
        /// Gets the post with the given ID.
        /// </summary>
        /// <returns>ViewModel containing one post.</returns>
        Task<BlogPostViewModel> GetBlogPostAsync(int id);

        /// <summary>
        /// Gets the posts in a category.
        /// </summary>
        /// <returns>ViewModel containing all posts in given category.</returns>
        CategoryViewModel GetBlogPostsInCategory(int id);
        /// <summary>
        /// Gets the posts in a category.
        /// </summary>
        /// <returns>ViewModel containing all posts in given category.</returns>
        Task<CategoryViewModel> GetBlogPostsInCategoryAsync(int id);

        /// <summary>
        /// Adds a new blog post.
        /// </summary>
        void CreateBlogPost(BlogPost newPost);
        /// <summary>
        /// Adds a new blog post.
        /// </summary>
        Task CreateBlogPostAsync(BlogPost newPost);

        /// <summary>
        /// Adds a new Text content chunk.
        /// </summary>
        Task AddTextContentChunkAsync(TextContentChunk theChunk);

        /// <summary>
        /// Adds a new Image content chunk.
        /// </summary>
        Task AddImageContentChunkAsync(ImageContentChunk theChunk);

        /// <summary>
        /// Adds a new Code content chunk.
        /// </summary>
        Task AddCodeContentChunkAsync(CodeContentChunk theChunk);

        /// <summary>
        /// Adds a new Video content chunk.
        /// </summary>
        Task AddVideoContentChunkAsync(VideoContentChunk theChunk);
    }
}
