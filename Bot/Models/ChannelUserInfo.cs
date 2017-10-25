using System;
using Microsoft.Bot.Connector;

namespace Bot.Models
{
    public class ChannelUserInfo
    {
        public ChannelUserInfo(IMessageActivity message)
        {
            ChannelId = message.ChannelId;
            UserId = message.From.Id;
        }

        public string ChannelId { get; }

        public string UserId { get; }
    }
}