using System;

namespace Domain
{
    /// <summary>
    /// User registered on one of chat bot channels.
    /// </summary>
    public class UserBotChannel
    {
        public string ChannelType { get; set; }

        public string UserEmail { get; set; }

        public string ChannelUserId { get; set; }
    }
}