using System;
using System.Collections;
using System.Collections.Generic;

namespace Bot.Models
{
    public class ApplicationOptions : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "Submit link";
            yield return "Get recommendation";
            yield return "Just chat";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}