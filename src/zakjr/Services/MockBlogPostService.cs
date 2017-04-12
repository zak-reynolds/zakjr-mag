using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using zakjr.Models;
using zakjr.ViewModels;

namespace zakjr.Services
{
    public class MockBlogPostService : IBlogPostService
    {
        public void CreateBlogPost(BlogPost newPost)
        {
            throw new NotImplementedException();
        }

        public async Task CreateBlogPostAsync(BlogPost newPost)
        {
            throw new NotImplementedException();
        }

        public BlogPostViewModel GetBlogPost(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BlogPostViewModel> GetBlogPostAsync(int id)
        {
            // This gets a random collection of ipsum
            HttpClient hc = new HttpClient();
            var ipsResponse3 = await hc.GetAsync("https://baconipsum.com/api/?type=meat-and-filler&sentences=3&format=text");
            var ipsResponse5 = await hc.GetAsync("https://baconipsum.com/api/?type=meat-and-filler&sentences=5&format=text");
            var ipsResponse1 = await hc.GetAsync("https://baconipsum.com/api/?type=meat-and-filler&sentences=1&format=text");
            string ipsString1 = await ipsResponse1.Content.ReadAsStringAsync();
            string ipsString3 = await ipsResponse3.Content.ReadAsStringAsync();
            string ipsString5 = await ipsResponse5.Content.ReadAsStringAsync();


            var result = new BlogPostViewModel();
            result.ThePost = new BlogPost()
            {
                ID = -1,
                FeaturedImage = "http://localhost:55671/images/cover1.jpg",
                Title = "A Test of Homestead",
                Subtitle = "This is a mocked blog post-- remind Zak to link this up to the db!",
                PostDate = DateTime.Now.AddDays(-45),
                UpdatedDate = DateTime.Now,
                Category = new Category()
                {
                    ID = -1,
                    Name = "Homestead",
                    Tagline = "A mocked category"
                },
                CategoryID = -1,
                ContentList = new List<ContentChunk>()
                {
                    new TextContentChunk()
                    {
                        Content = ipsString3
                    },
                    new ImageContentChunk()
                    {
                        ID = 1,
                        ImageUrl = "http://zakjr.com/blog/wp-content/uploads/2016/03/betsy-768x432.png",
                        CanExpand = true,
                        ImageCaption = "Mocked image",
                        LoadingGradient = "linear-gradient(135deg, #627d4d 0%,#1f3b08 100%)"
                    },
                    new TextContentChunk()
                    {
                        Content = ipsString5
                    },
                    new TextContentChunk()
                    {
                        Content = ipsString1
                    },
                    new ImageContentChunk()
                    {
                        ID = 2,
                        ImageUrl = "http://zakjr.com/blog/wp-content/uploads/2016/02/Homestead-0001-768x402.png",
                        CanExpand = true,
                        ImageCaption = "Mocked image",
                        LoadingGradient = "linear-gradient(135deg, #627d4d 0%,#1f3b08 100%)"
                    },
                    new TextContentChunk()
                    {
                        Content = ipsString3
                    },
                    new CodeContentChunk()
                    {
                        Content = "int LifeUniverseEverything(string question) { return 42; }",
                        CodeLanguage = "cs"
                    },
                    new TextContentChunk()
                    {
                        Content = ipsString5
                    },
                    new ImageContentChunk()
                    {
                        ID = 3,
                        ImageUrl = "http://zakjr.com/blog/wp-content/uploads/2015/11/homestead-first-dialogue-1024x576.png",
                        CanExpand = true,
                        ImageCaption = "Mocked image",
                        LoadingGradient = "linear-gradient(135deg, #627d4d 0%,#1f3b08 100%)"
                    },
                    new TextContentChunk()
                    {
                        Content = ipsString3
                    }
                },
                Comments = new List<Comment>()
                {
                    new Comment() {
                        Author = "Mock",
                        Content = ipsString1,
                        PostDate = DateTime.Now,
                        Comments = new List<Comment>()
                        {
                            new Comment() {
                                Author = "Mock",
                                Content = ipsString3,
                                PostDate = DateTime.Now
                            }
                        }
                    },
                    new Comment() {
                        Author = "Mock",
                        Content = ipsString1,
                        PostDate = DateTime.Now
                    },
                    new Comment() {
                        Author = "Mock",
                        Content = ipsString3,
                        PostDate = DateTime.Now,
                        Comments = new List<Comment>()
                        {
                            new Comment() {
                                Author = "Mock",
                                Content = ipsString1,
                                PostDate = DateTime.Now,
                                Comments = new List<Comment>()
                                {
                                    new Comment() {
                                        Author = "Mock",
                                        Content = ipsString3,
                                        PostDate = DateTime.Now
                                    },
                                    new Comment() {
                                        Author = "Mock",
                                        Content = ipsString5,
                                        PostDate = DateTime.Now
                                    }
                                }
                            }
                        }
                    }
                }
            };
            result.TheComments = new CommentSection()
            {
                HeaderText = "Convey a thought",
                CommentList = result.ThePost.Comments
            };
            result.TheCover = new BlogPostCover()
            {
                CoverImage = result.ThePost.FeaturedImage,
                Title = result.ThePost.Title,
                TagLine = result.ThePost.Subtitle
            };
            result.TheNavigation = new List<NavItem>()
            {
                new NavItem()
                {
                    Url = "#",
                    DisplayText = "Mock"
                },
                new NavItem()
                {
                    Url = "#",
                    DisplayText = "Mock Cat"
                },
                new NavItem()
                {
                    Url = "#",
                    DisplayText = "Current Page"
                }
            };


            await Task.Delay(200);

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
        public Task AddTextContentChunk(TextContentChunk theChunk)
        {
            throw new NotImplementedException();
        }

        public Task AddTextContentChunkAsync(TextContentChunk theChunk)
        {
            throw new NotImplementedException();
        }

        public Task AddImageContentChunkAsync(ImageContentChunk theChunk)
        {
            throw new NotImplementedException();
        }

        public Task AddCodeContentChunkAsync(CodeContentChunk theChunk)
        {
            throw new NotImplementedException();
        }

        public Task AddVideoContentChunkAsync(VideoContentChunk theChunk)
        {
            throw new NotImplementedException();
        }
    }
}
