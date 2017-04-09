using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zakjr.Models
{
    public class CommentSection
    {
        public string HeaderText { get; set; }
        public IEnumerable<Comment> CommentList { get; set; }
    }
}
