using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using zakjr_mag.Data;
using zakjr_mag.Models;

namespace zakjr_mag.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BlogContext context)
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
                    Content="<p class='m-all t-all d-all'>After working through the design and project planning for nearly a month, I’m feeling really good about the state of Homestead.Some planning still needs to be done, but I have detailed lists and designs for everything that will be included in the prototype and the basic version of the game.Now that I have a stronger roadmap, I’m splitting my time between working on the prototype and finishing the rest of the design.</p>        <p class='m-all t-all d-2of5'>The fishing system is something that I’ve been looking forward to implementing for a long time.There will be both a metagame and minigame surrounding fishing in Homestead.I’ve been prototyping the minigame to tune it and make sure the idea is actually fun, and it is! Apparently cabbages are harder to catch than you’d think:</p>        <div class='flex-video'>            <video loop = '' autoplay=''>                <source src = 'http://zakjr.com/blog/wp-content/uploads/2016/08/2016-08-30-18-23-34.mp4' type='video/mp4'>Your browser does not support the video tag.                </video>        </div><br>        <p class='m-all t-all d-all'>The minigame boils down to timing and balancing the line tension(the white-on-black bar) against the fish(or… cabbage…) using its stamina to escape.If the tension is too high for too long, the hook will come loose with a chance of snapping the line and losing the tackle.The box in the lower-left corner is a quick-and-dirty indicator of the rod state: Grey represents rod down, letting the fish escape but lowering tension; Green represents rod up, which slows the fish and increases tension; and Red represents reeling, which is done by spinning the right control stick(although I have also implemented pluggable, substitute controls that allow for button tapping or button holding to keep the game accessible). The fish can jump, too!</p>        <p class='m-all t-all d-all'>The metagame involves different types of tackle, fish, time, day, and differing methods for attracting different fish, but I’ll reveal more about that when it’s actually implemented.I’m going to keep this post short and sweet, so until next time! </p>"
                    //CategoryID =0
                },
                new BlogPost {
                    Title="Blendering for Unity: Introduction",
                    Subtitle="",
                    PostDate=DateTime.Now,
                    UpdatedDate=null,
                    FeaturedImage="http://zakjr.com/blog/wp-content/uploads/2016/08/fishing-feature-1024x426.jpg",
                    Content="<p class='m-all t-all d-all'>After working through the design and project planning for nearly a month, I’m feeling really good about the state of Homestead.Some planning still needs to be done, but I have detailed lists and designs for everything that will be included in the prototype and the basic version of the game.Now that I have a stronger roadmap, I’m splitting my time between working on the prototype and finishing the rest of the design.</p>        <p class='m-all t-all d-2of5'>The fishing system is something that I’ve been looking forward to implementing for a long time.There will be both a metagame and minigame surrounding fishing in Homestead.I’ve been prototyping the minigame to tune it and make sure the idea is actually fun, and it is! Apparently cabbages are harder to catch than you’d think:</p>        <div class='flex-video'>            <video loop = '' autoplay=''>                <source src = 'http://zakjr.com/blog/wp-content/uploads/2016/08/2016-08-30-18-23-34.mp4' type='video/mp4'>Your browser does not support the video tag.                </video>        </div><br>        <p class='m-all t-all d-all'>The minigame boils down to timing and balancing the line tension(the white-on-black bar) against the fish(or… cabbage…) using its stamina to escape.If the tension is too high for too long, the hook will come loose with a chance of snapping the line and losing the tackle.The box in the lower-left corner is a quick-and-dirty indicator of the rod state: Grey represents rod down, letting the fish escape but lowering tension; Green represents rod up, which slows the fish and increases tension; and Red represents reeling, which is done by spinning the right control stick(although I have also implemented pluggable, substitute controls that allow for button tapping or button holding to keep the game accessible). The fish can jump, too!</p>        <p class='m-all t-all d-all'>The metagame involves different types of tackle, fish, time, day, and differing methods for attracting different fish, but I’ll reveal more about that when it’s actually implemented.I’m going to keep this post short and sweet, so until next time! </p>"
                    //CategoryID=1
                },
                new BlogPost {
                    Title="Stuff I Made",
                    Subtitle="",
                    PostDate=DateTime.Now,
                    UpdatedDate=null,
                    FeaturedImage="http://zakjr.com/blog/wp-content/uploads/2016/08/fishing-feature-1024x426.jpg",
                    Content="<p class='m-all t-all d-all'>After working through the design and project planning for nearly a month, I’m feeling really good about the state of Homestead.Some planning still needs to be done, but I have detailed lists and designs for everything that will be included in the prototype and the basic version of the game.Now that I have a stronger roadmap, I’m splitting my time between working on the prototype and finishing the rest of the design.</p>        <p class='m-all t-all d-2of5'>The fishing system is something that I’ve been looking forward to implementing for a long time.There will be both a metagame and minigame surrounding fishing in Homestead.I’ve been prototyping the minigame to tune it and make sure the idea is actually fun, and it is! Apparently cabbages are harder to catch than you’d think:</p>        <div class='flex-video'>            <video loop = '' autoplay=''>                <source src = 'http://zakjr.com/blog/wp-content/uploads/2016/08/2016-08-30-18-23-34.mp4' type='video/mp4'>Your browser does not support the video tag.                </video>        </div><br>        <p class='m-all t-all d-all'>The minigame boils down to timing and balancing the line tension(the white-on-black bar) against the fish(or… cabbage…) using its stamina to escape.If the tension is too high for too long, the hook will come loose with a chance of snapping the line and losing the tackle.The box in the lower-left corner is a quick-and-dirty indicator of the rod state: Grey represents rod down, letting the fish escape but lowering tension; Green represents rod up, which slows the fish and increases tension; and Red represents reeling, which is done by spinning the right control stick(although I have also implemented pluggable, substitute controls that allow for button tapping or button holding to keep the game accessible). The fish can jump, too!</p>        <p class='m-all t-all d-all'>The metagame involves different types of tackle, fish, time, day, and differing methods for attracting different fish, but I’ll reveal more about that when it’s actually implemented.I’m going to keep this post short and sweet, so until next time! </p>"
                    //CategoryID=2
                }
            };
            foreach (BlogPost b in blogPosts)
            {
                context.Add(b);
            }

            context.SaveChanges();
        }
    }
}
