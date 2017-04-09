using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace zakjr.Models
{
    public class TextContentChunk : ContentChunk
    {
        public void SetContent(string value)
        {
            Content = WebUtility.HtmlEncode(value);
        }
    }
}
