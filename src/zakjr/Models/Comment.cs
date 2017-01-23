using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zakjr.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Content { get; set; }

        public int BlogPostID { get; set; }
        public int? CommentID { get; set; }

        public virtual BlogPost BlogPost { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
