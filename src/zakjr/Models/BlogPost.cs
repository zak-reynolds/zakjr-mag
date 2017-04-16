using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zakjr.Models
{
    public class BlogPost
    {
        public int ID { get; set; }
        [StringLength(60)]
        //[Column(TypeName ="varchar")]
        // sticking with nvarchar for Unicode support
        // http://stackoverflow.com/questions/144283/what-is-the-difference-between-varchar-and-nvarchar#147302
        public string Title { get; set; }
        [StringLength(60)]
        public string Subtitle { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [RegularExpression(@"(\b(https?):\/\/)?[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|](\.jpg|\.png|\.gif|\.svg)", ErrorMessage = "Featured image must be a URL path to a png, jpg, svg, or gif")]
        public string FeaturedImage { get; set; }
        public bool IsPublished { get; set; }
        public string Slug { get; set; }

        //[InverseProperty("BlogPostID")]
        public virtual List<TextContentChunk> TextContentList { get; set; }
        public virtual List<ImageContentChunk> ImageContentList { get; set; }
        public virtual List<CodeContentChunk> CodeContentList { get; set; }
        public virtual List<VideoContentChunk> VideoContentList { get; set; }

        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
