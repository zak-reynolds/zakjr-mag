using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zakjr_mag.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Content { get; set; }

        public int BlogPostID { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
