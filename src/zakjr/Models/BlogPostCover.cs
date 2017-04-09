using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zakjr.Models
{
    public class BlogPostCover
    {
        [RegularExpression(@"(\b(https?):\/\/)?[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|](\.jpg|\.png|\.gif|\.svg)", ErrorMessage = "Cover image must be a URL path to a png, jpg, svg, or gif")]
        public string CoverImage { get; set; }
        public string Title { get; set; }
        public string TagLine { get; set; }

        public int BlogPostID { get; set; }
    }
}
