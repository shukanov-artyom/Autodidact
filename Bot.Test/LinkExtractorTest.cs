using System;
using Bot.Utils;
using Xunit;

namespace Bot.Test
{
    public class LinkExtractorTest
    {
        [Theory]
        [InlineData(
            "Hello here is a link https://somewebsite.com/article.html",
            "https://somewebsite.com/article.html")]
        public void TestExtraction(string text, string expectedResult)
        {
            var extractor = new LinkExtractor(text);
            string actualResult = extractor.ExtractLink();
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
