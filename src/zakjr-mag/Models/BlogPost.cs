using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zakjr_mag.Models
{
    public class BlogPost
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string FeaturedImage { get; set; }
        public string Content { get; set; }

        public int? CategoryID { get; set; }

        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
