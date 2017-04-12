using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zakjr.Models
{
    public class CodeContentChunk : ContentChunk
    {
        [Required]
        [StringLength(15)]
        public string CodeLanguage { get; set; }

        public string Content { get; set; }
    }
}
