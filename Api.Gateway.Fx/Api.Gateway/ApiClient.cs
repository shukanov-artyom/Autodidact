using System;
using Api.Interfaces;
using Bot.Api.Gateway;
using Domain;

namespace Api.Gateway.Fx.Api.Gateway
{
    public class ApiClient : WebServiceClientBase, IAutodidactApi, IDisposable
    {
        public ApiClient(ApiSettings settings)
            : base(settings.ApiEndpointAddress)
        {
        }

        public UserRegistrationStatus IsUserRegistered(UserBotChannel user)
        {
            return Post<UserRegistrationStatus>("api/User/IsRegistered", user);
        }

        public string GetConfirmationCode(
            long userId,
            string channelId,
            string channelUserId)
        {
            var dto = new UserConfirmationCodeInfoDto()
            {
                UserId = userId,
                ChannelId = channelId,
                ChannelUserId = channelUserId
            };
            return PostGetString("api/User/ConfirmationCode", dto);
        }

        public void ActivateConfirmationCode(
            string channelId, 
            string channelUserId,
            Guid code)
        {
            var payload = new ActivateConfirmationCodeDto(channelId, channelUserId, code);
            Post("api/User/ActivateConfirmationCode", payload);
        }

        public void Dispose()
        {
            // nothing here yet
        }
    }
}
