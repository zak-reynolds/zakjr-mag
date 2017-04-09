using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zakjr.Models;

namespace zakjr.ViewModels
{
    public class BlogPostViewModel
    {
        public BlogPost ThePost { get; set; }

        public IEnumerable<NavItem> TheNavigation { get; set; }

        public BlogPostCover TheCover { get; set; }

        public CommentSection TheComments { get; set; }
    }
}
