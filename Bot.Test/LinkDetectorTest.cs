using System;
using Bot.Utils;
using Xunit;

namespace Bot.Test
{
    public class LinkDetectorTest
    {
        [Theory]
        [InlineData(
            "https://twitter.com/",
            true)]
        [InlineData(
            "twitter.com",
            false)]
        public void TestLinkDetection(string link, bool expectedResult)
        {
            var result = new LinkDetector(link).IsLink();
            Assert.Equal(expectedResult, result);
        }
    }
}
