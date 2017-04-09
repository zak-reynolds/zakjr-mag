using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zakjr.Models;

namespace zakjr.ViewModels
{
    public class CategoryViewModel
    {
        /// <summary>
        /// An ordered list of blog posts in category, sorted most recent to least recent.
        /// </summary>
        public List<BlogPost> OrderedBlogPosts { get; set; }
    }
}
