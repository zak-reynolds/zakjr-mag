using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Markdig;
using System.Text.RegularExpressions;

namespace zakjr.Models
{
    public class TextContentChunk : ContentChunk
    {
        public string Content { get; set; }

        private string _contentHtml;
        public string ContentHtml {
            get
            {
                if (String.IsNullOrEmpty(_contentHtml))
                {
                    // TODO: Cache
                    _contentHtml = Markdown.ToHtml(Content);
                    _contentHtml = Regex.Replace(_contentHtml, @"<script([\s\S])+script\s*>", String.Empty);
                }
                return _contentHtml;
            }
        }
    }
}
