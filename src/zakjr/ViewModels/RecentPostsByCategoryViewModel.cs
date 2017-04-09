using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zakjr.Models;

namespace zakjr.ViewModels
{
    public class RecentPostsByCategoryViewModel
    {
        /// <summary>
        /// Key: Category ID
        /// Value: Most recent blog post in category
        /// </summary>
        public Dictionary<int, BlogPost> PostsByCategory { get; set; }
    }
}
