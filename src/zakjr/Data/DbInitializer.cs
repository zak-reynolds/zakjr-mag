using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using zakjr.Models;
using zakjr.Data;

namespace zakjr_mag.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category {Name="Homestead",Tagline="Posts about my current project, a farming RPG! Read about my progress, techniques, and see lots of eye-candy!"},
                new Category {Name="Blendering for Unity",Tagline="A tutorial series geared towards those with no experience making 3D models! Learn to make your own assets for your Unity projects!"},
                new Category {Name="Zak's Portfolio",Tagline="I've done a bunch of stuff, and you can see a bunch of it here! Prepare to see lots of little game jam games!"}
            };
            foreach (Category c in categories)
            {
                context.Add(c);
            }

            var blogPosts = new BlogPost[]
            {
                new BlogPost {
                    Title="Prototyping Fishing",
                    Subtitle="",
                    PostDate=DateTime.Now,
                    UpdatedDate=null,
                    FeaturedImage="http://zakjr.com/blog/wp-content/uploads/2016/08/fishing-feature-1024x426.jpg",
                    CategoryID = categories[0].ID
                },
                new BlogPost {
                    Title="Blendering for Unity: Introduction",
                    Subtitle="",
                    PostDate=DateTime.Now,
                    UpdatedDate=null,
                    FeaturedImage="http://zakjr.com/blog/wp-content/uploads/2016/08/fishing-feature-1024x426.jpg",
                    CategoryID = categories[1].ID
                },
                new BlogPost {
                    Title="Stuff I Made",
                    Subtitle="",
                    PostDate=DateTime.Now,
                    UpdatedDate=null,
                    FeaturedImage="http://zakjr.com/blog/wp-content/uploads/2016/08/fishing-feature-1024x426.jpg",
                    CategoryID = categories[2].ID
                }
            };
            foreach (BlogPost b in blogPosts)
            {
                context.Add(b);
            }
            var contentChunks = new TextContentChunk[]
            {
                    new TextContentChunk { BlogPostID=blogPosts[0].ID, Content="After working through the design and project planning for nearly a month, I’m feeling really good about the state of Homestead. Some planning still needs to be done, but I have detailed lists and designs for everything that will be included in the prototype and the basic version of the game. Now that I have a stronger roadmap, I’m splitting my time between working on the prototype and finishing the rest of the design." },
                    new TextContentChunk { BlogPostID=blogPosts[0].ID, Content="The fishing system is something that I’ve been looking forward to implementing for a long time. There will be both a metagame and minigame surrounding fishing in Homestead. I’ve been prototyping the minigame to tune it and make sure the idea is actually fun, and it is!" },
                    new TextContentChunk { BlogPostID=blogPosts[0].ID, Content="Apparently cabbages are harder to catch than you’d think:" },
                    new TextContentChunk { BlogPostID=blogPosts[0].ID, Content="VIDEO GOES HERE" },
                    new TextContentChunk { BlogPostID=blogPosts[0].ID, Content="The minigame boils down to timing and balancing the line tension (the white-on-black bar) against the fish (or… cabbage…) using its stamina to escape. If the tension is too high for too long, the hook will come loose with a chance of snapping the line and losing the tackle. The box in the lower-left corner is a quick-and-dirty indicator of the rod state: Grey represents rod down, letting the fish escape but lowering tension; Green represents rod up, which slows the fish and increases tension; and Red represents reeling, which is done by spinning the right control stick (although I have also implemented pluggable, substitute controls that allow for button tapping or button holding to keep the game accessible). The fish can jump, too!" },
                    new TextContentChunk { BlogPostID=blogPosts[0].ID, Content="The metagame involves different types of tackle, fish, time, day, and differing methods for attracting different fish, but I’ll reveal more about that when it’s actually implemented. I’m going to keep this post short and sweet, so until next time!" },

                    new TextContentChunk { BlogPostID=blogPosts[1].ID, Content="Blendering for Unity blah blah" },
                    new TextContentChunk { BlogPostID=blogPosts[1].ID, Content="Hidy ho hidy ho" },
                    new TextContentChunk { BlogPostID=blogPosts[1].ID, Content="Blender is cool" },
                    new TextContentChunk { BlogPostID=blogPosts[1].ID, Content="SCREEN GOES HERE" },

                    new TextContentChunk { BlogPostID=blogPosts[2].ID, Content="Portfolio schmortfolieo" },
                    new TextContentChunk { BlogPostID=blogPosts[2].ID, Content="Sippydipoodoop" },
                    new TextContentChunk { BlogPostID=blogPosts[2].ID, Content="Nonesnes" },
                    new TextContentChunk { BlogPostID=blogPosts[2].ID, Content="Not a Super Nintendo, nonsense!" }
            };
            foreach (TextContentChunk cc in contentChunks)
            {
                context.Add(cc);
            }
            var comments = new Comment[]
            {
                new Comment
                {
                    Author="Alex",
                    Content="This is muh comment bruh",
                    PostDate=DateTime.Now,
                    BlogPostID=blogPosts[0].ID
                },
                new Comment
                {
                    Author="Bob",
                    Content="Another snarky top-level comment",
                    PostDate=DateTime.Now.AddMinutes(1),
                    BlogPostID=blogPosts[0].ID
                },
                new Comment
                {
                    Author="Charlie",
                    Content="Top-level comment the third",
                    PostDate=DateTime.Now.AddMinutes(2),
                    BlogPostID=blogPosts[0].ID
                },
                new Comment
                {
                    Author="Alex",
                    Content="This is muh comment on the Blender stuff bruh",
                    PostDate=DateTime.Now,
                    BlogPostID=blogPosts[1].ID
                },
                new Comment
                {
                    Author="Bob",
                    Content="Another snarky top-level comment about how Blender and Unity should be unified",
                    PostDate=DateTime.Now.AddMinutes(1),
                    BlogPostID=blogPosts[1].ID
                },
                new Comment
                {
                    Author="Charlie",
                    Content="Top-level comment the second the second",
                    PostDate=DateTime.Now.AddMinutes(2),
                    BlogPostID=blogPosts[1].ID
                },
                new Comment
                {
                    Author="Alex",
                    Content="This is muh comment bruh, sick portfolio",
                    PostDate=DateTime.Now,
                    BlogPostID=blogPosts[2].ID
                },
                new Comment
                {
                    Author="Bob",
                    Content="His earlier stuff was better",
                    PostDate=DateTime.Now.AddMinutes(1),
                    BlogPostID=blogPosts[2].ID
                },
                new Comment
                {
                    Author="Charlie",
                    Content="Top-level comment the third the third",
                    PostDate=DateTime.Now.AddMinutes(2),
                    BlogPostID=blogPosts[2].ID
                }
            };
            foreach (Comment c in comments)
            {
                context.Add(c);
            }

            context.SaveChanges();
        }
    }
}
