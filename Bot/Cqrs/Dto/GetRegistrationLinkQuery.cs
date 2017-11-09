using System;
using Bot.CQRS.Query;
using Bot.Models;
using Bot.Settings;
using Bot.Utils;

namespace Bot.Cqrs.Dto
{
    public class GetRegistrationLinkQuery : IQuery<string>
    {
        private readonly ChannelUserInfo user;

        public GetRegistrationLinkQuery(ChannelUserInfo user)
        {
            this.user = user;
        }

        public SecurityTokenServiceSettings TokenServerSettings { get; set; }

        public string Run()
        {
            return new RegistrationLinkFactory(TokenServerSettings.EndpointAddress)
                .GenerateLink(user);
        }
    }
}