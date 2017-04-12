using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zakjr.Models
{
    public abstract class ContentChunk
    {
        public int ID { get; set; }
        public int Sequence { get; set; }

        public int BlogPostID { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}
