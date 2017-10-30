using System;
using Bot.Models;

namespace Bot.Utils
{
    public class RegistrationLinkFactory
    {
        private readonly string securityTokenServiceBaseUrl;

        public RegistrationLinkFactory(
            string securityTokenServiceBaseUrl)
        {
            this.securityTokenServiceBaseUrl = securityTokenServiceBaseUrl;
        }

        public string GenerateLink(ChannelUserInfo user)
        {
            string channelId = user.ChannelId;
            string userId = user.UserId;
            var builder = new UriBuilder();
            builder.Scheme = "https";
            builder.Host = securityTokenServiceBaseUrl;
            builder.Path = "BotAccount/Register";
            builder.Query = $"ChannelId={channelId}&UserId={userId}";
            return builder.ToString();
        }
    }
}