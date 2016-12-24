using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zakjr_mag.Data;
using zakjr_mag.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace zakjr_mag.Controllers
{
    public class AdminController : Controller
    {
        private readonly BlogContext _context;

        public AdminController(BlogContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.BlogPosts.ToListAsync());
        }

        public async Task<IActionResult> Edit(int id)
        {
            var postModel = await _context.BlogPosts
                .Include(post => post.ContentList)
                .SingleOrDefaultAsync(post => post.ID == id);
            return View(postModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var postToUpdate = await _context.BlogPosts
                .Include(post => post.ContentList)
                .SingleOrDefaultAsync(post => post.ID == id);
            postToUpdate.UpdatedDate = DateTime.Now;
            if (await TryUpdateModelAsync<BlogPost>(
                postToUpdate, "",
                post => post.Title,
                post => post.Subtitle,
                post => post.UpdatedDate,
                post => post.FeaturedImage,
                post => post.ContentList))
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
            return View(postToUpdate);
        }
    }
}
