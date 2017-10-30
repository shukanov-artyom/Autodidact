using System;
using Bot.Models;
using Bot.Utils;
using Xunit;

namespace Bot.Test
{
    public class RegistrationLinkFactoryTest
    {
        [Theory]
        [InlineData(
            "sts.endpoint.com",
            "SOMECHANNELID",
            "SOMEUSERID",
            "https://sts.endpoint.com/BotAccount/Register?ChannelId=SOMECHANNELID&UserId=SOMEUSERID")]
        public void PositiveCase(
            string stsEndpointUrl,
            string channelId,
            string userId,
            string expectedResult)
        {
            var factory = new RegistrationLinkFactory(stsEndpointUrl);
            ChannelUserInfo user = new ChannelUserInfo(
                channelId,
                userId);
            string result = factory.GenerateLink(user);
            Assert.Equal(expectedResult, result);
        }
    }
}
