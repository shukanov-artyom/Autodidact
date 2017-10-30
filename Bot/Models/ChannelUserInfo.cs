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

        public ChannelUserInfo(
            string channelId,
            string userId)
        {
            ChannelId = channelId;
            UserId = userId;
        }

        public string ChannelId { get; }

        public string UserId { get; }
    }
}