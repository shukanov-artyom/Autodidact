using System;

namespace Bot.Utils
{
    public class LinkDetector
    {
        private readonly string maybeLink;

        public LinkDetector(string maybeLink)
        {
            this.maybeLink = maybeLink;
        }

        public bool IsLink()
        {
            return maybeLink.StartsWith("http://") ||
                   maybeLink.StartsWith("https://");
        }
    }
}