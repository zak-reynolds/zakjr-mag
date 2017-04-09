using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zakjr.Models
{
    public class VideoContentChunk : ContentChunk
    {
        [Required]
        [Url(ErrorMessage = "VideoURL must be a URL path to a video")]
        public string VideoUrl { get; set; }

        [Required]
        public bool VideoIsWidescreen { get; set; }
    }
}
