using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zakjr.Data;
using Microsoft.EntityFrameworkCore;

namespace zakjr.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ////TODO: Handle multiple posts with same postdate, clean up

            //DateTime aMax = await _context.BlogPosts
            //    .Where(bp => bp.CategoryID == _context.Categories.FirstOrDefault(cat => cat.Name.Contains("Homestead")).ID)
            //    .MaxAsync(bp => bp.PostDate);
            //DateTime bMax = await _context.BlogPosts
            //    .Where(bp => bp.CategoryID == _context.Categories.FirstOrDefault(cat => cat.Name.Contains("Blender")).ID)
            //    .MaxAsync(bp => bp.PostDate);
            //DateTime cMax = await _context.BlogPosts
            //    .Where(bp => bp.CategoryID == _context.Categories.FirstOrDefault(cat => cat.Name.Contains("Portfolio")).ID)
            //    .MaxAsync(bp => bp.PostDate);

            //var blogPostsAsync = await _context.BlogPosts
            //    .Where(bp =>
            //        (bp.CategoryID == _context.Categories.FirstOrDefault(cat => cat.Name.Contains("Homestead")).ID && bp.PostDate == aMax) ||
            //        (bp.CategoryID == _context.Categories.FirstOrDefault(cat => cat.Name.Contains("Blender")).ID && bp.PostDate == bMax) ||
            //        (bp.CategoryID == _context.Categories.FirstOrDefault(cat => cat.Name.Contains("Portfolio")).ID && bp.PostDate == cMax))
            //    .Include(bp => bp.TextContentList)
            //    .Include(bp => bp.ImageContentList)
            //    .Include(bp => bp.CodeContentList)
            //    .Include(bp => bp.VideoContentList)
            //    .Include(bp => bp.Comments)
            //    .ToListAsync();

            //return View(blogPostsAsync);
            Response.Redirect("blog");
            return new EmptyResult();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
