using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zakjr.Models
{
    public class ImageContentChunk : ContentChunk
    {
        [Required]
        [RegularExpression(@"(\b(https?):\/\/)?[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|](\.jpg|\.png|\.gif|\.svg)", ErrorMessage = "ImageURL must be a URL path to a png, jpg, svg, or gif")]
        public string ImageUrl { get; set; }

        // TODO: Encode HTML
        [Required]
        public string ImageAlt { get; set; }

        [Required]
        public bool CanExpand { get; set; }

        public string LoadingGradient { get; set; }

        // TODO: Encode HTML
        [StringLength(150)]
        public string ImageCaption { get; set; }
    }
}
