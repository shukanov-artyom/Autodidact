using System;

namespace Api.DataModel
{
    public class DocumentEntity
    {
        public long Id { get; set; }

        public long ChannelUserId { get; set; }

        public string Link { get; set; }

        public int Rating { get; set; }

        public DateTimeOffset SubmitDate { get; set; }
    }
}
