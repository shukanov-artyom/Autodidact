using System;

namespace Domain
{
    /// <summary>
    /// Document by user's link.
    /// </summary>
    public class Document
    {
        public string Link { get; set; }

        public int Rating { get; set; }

        public DateTimeOffset SubmitDate { get; set; }

        public string SubmitterEmail { get; set; }
    }
}