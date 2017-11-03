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
            Uri baseEndpointUri = new Uri(securityTokenServiceBaseUrl);
            string channelId = user.ChannelId;
            string userId = user.UserId;
            var builder = new UriBuilder();
            builder.Scheme = baseEndpointUri.Scheme;
            builder.Host = baseEndpointUri.Host;
            builder.Port = baseEndpointUri.Port;
            builder.Path = "BotAccount/Register";
            builder.Query = $"BotChannelType={channelId}&BotChannelUserId={userId}";
            return builder.ToString();
        }
    }
}