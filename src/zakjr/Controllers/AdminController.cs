using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zakjr.Data;
using zakjr.Models;
using zakjr.Services;

namespace zakjr.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // TODO: Remove dependency on ADC (should be in bps)
        private readonly ApplicationDbContext _context;
        private readonly IBlogPostService _blogPostService;

        public AdminController(
            ApplicationDbContext context,
            IBlogPostService blogPostService)
        {
            _context = context;
            _blogPostService = blogPostService;
        }

        public async Task<IActionResult> Index()
        {
            InitViewBag();
            return View(await _context.BlogPosts.ToListAsync());
        }

        public async Task<IActionResult> Edit(int id)
        {
            var postModel = await _context.BlogPosts
                .Include(post => post.TextContentList)
                .Include(post => post.ImageContentList)
                .Include(post => post.CodeContentList)
                .Include(post => post.VideoContentList)
                .SingleOrDefaultAsync(post => post.ID == id);
            InitViewBag();
            return View(postModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var postToUpdate = await _context.BlogPosts
                .Include(post => post.TextContentList)
                .Include(post => post.ImageContentList)
                .Include(post => post.CodeContentList)
                .Include(post => post.VideoContentList)
                .SingleOrDefaultAsync(post => post.ID == id);
            postToUpdate.UpdatedDate = DateTime.Now;

            if (await TryUpdateModelAsync<BlogPost>(
                postToUpdate, "",
                post => post.Title,
                post => post.Subtitle,
                post => post.UpdatedDate,
                post => post.IsPublished,
                post => post.Slug,
                post => post.FeaturedImage,
                post => post.TextContentList,
                post => post.ImageContentList,
                post => post.CodeContentList,
                post => post.VideoContentList))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Edit");
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes :c");
                }
            }
            //TODO: Shouldn't need to do this
            InitViewBag();
            return View(postToUpdate);
        }

        //
        // Blog post
        [HttpGet]
        public IActionResult CreateBlogPost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBlogPost(
            [Bind("Title,Subtitle,FeaturedImage,CategoryID,IsPublished,Slug")] BlogPost thePost)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _blogPostService.CreateBlogPostAsync(thePost);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", String.Format(
                    @"Could not save changes. Try again in a few. :: {0} :: {1}",
                    e.Message,
                    e.InnerException.Message));
            }
            return View(thePost);
        }

        //
        // Text Content Chunk
        [HttpGet]
        public IActionResult AddTextContentChunk(int id = 0)
        {
            TextContentChunk newChunk = new TextContentChunk() { BlogPostID = id, Sequence = -1 };
            return View(newChunk);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTextContentChunk(
            [Bind("Sequence,BlogPostID,Content")] TextContentChunk theChunk)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _blogPostService.AddTextContentChunkAsync(theChunk);
                    return RedirectToAction("Edit", new { id = theChunk.BlogPostID });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", String.Format(
                    @"Could not save changes. Try again in a few. :: {0} :: {1}",
                    e.Message,
                    e.InnerException.Message));
            }
            return View();
        }

        //
        // Image Content Chunk
        [HttpGet]
        public IActionResult AddImageContentChunk(int id = 0)
        {
            ImageContentChunk newChunk = new ImageContentChunk() { BlogPostID = id, Sequence = -1 };
            return View(newChunk);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImageContentChunk(
            [Bind("Sequence,BlogPostID,ImageUrl,ImageAlt,CanExpand,LoadingGradient,ImageCaption")] ImageContentChunk theChunk)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _blogPostService.AddImageContentChunkAsync(theChunk);
                    return RedirectToAction("Edit", new { id = theChunk.BlogPostID });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", String.Format(
                    @"Could not save changes. Try again in a few. :: {0} :: {1}",
                    e.Message,
                    e.InnerException.Message));
            }
            return View();
        }

        //
        // Code Content Chunk
        [HttpGet]
        public IActionResult AddCodeContentChunk(int id = 0)
        {
            CodeContentChunk newChunk = new CodeContentChunk() { BlogPostID = id, Sequence = -1 };
            return View(newChunk);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCodeContentChunk(
            [Bind("Sequence,BlogPostID,CodeLanguage,Content")] CodeContentChunk theChunk)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _blogPostService.AddCodeContentChunkAsync(theChunk);
                    return RedirectToAction("Edit", new { id = theChunk.BlogPostID });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", String.Format(
                    @"Could not save changes. Try again in a few. :: {0} :: {1}",
                    e.Message,
                    e.InnerException.Message));
            }
            return View();
        }

        //
        // Video Content Chunk
        [HttpGet]
        public IActionResult AddVideoContentChunk(int id = 0)
        {
            VideoContentChunk newChunk = new VideoContentChunk() { BlogPostID = id, Sequence = -1 };
            return View(newChunk);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVideoContentChunk(
            [Bind("Sequence,BlogPostID,VideoUrl,VideoIsWidescreen")] VideoContentChunk theChunk)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _blogPostService.AddVideoContentChunkAsync(theChunk);
                    return RedirectToAction("Edit", new { id = theChunk.BlogPostID });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", String.Format(
                    @"Could not save changes. Try again in a few. :: {0} :: {1}",
                    e.Message,
                    e.InnerException.Message));
            }
            return View();
        }

        protected void InitViewBag()
        {
            ViewBag.LoggedIn = false;
            ViewBag.Username = "Zak";
        }
    }
}
