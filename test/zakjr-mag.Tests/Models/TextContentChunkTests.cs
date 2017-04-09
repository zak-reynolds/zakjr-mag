using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using zakjr.Models;

namespace zakjr_mag.Tests.Models
{
    public class TextContentChunkTests
    {
        [Fact]
        public void HtmlIsEncoded()
        {
            // Arrange
            var textContentChunk = new TextContentChunk();

            // Act
            textContentChunk.SetContent(@"<script>This could be dangerous</script><p class='do not want'>Html should be added by app, not user</p>");

            // Assert
            Assert.False(
                textContentChunk.Content.Contains("<") ||
                textContentChunk.Content.Contains(">") ||
                textContentChunk.Content.Contains("'")
                );
        }
    }
}