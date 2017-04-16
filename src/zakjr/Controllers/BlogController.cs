using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zakjr.Services;
using zakjr.ViewModels;
using zakjr.Models;

namespace zakjr.Controllers
{
    public class BlogController : Controller
    {
        private IBlogPostService _blogPostService { get; }

        public BlogController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id = 1)
        {
            BlogPostViewModel vm = await _blogPostService.GetBlogPostAsync(id);

            if (!vm.ThePost.IsPublished) Response.Redirect("/error/404");

            return View(vm);
        }
    }
}