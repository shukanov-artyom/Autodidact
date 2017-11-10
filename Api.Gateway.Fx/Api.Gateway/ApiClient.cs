using System;
using Api.Interfaces;
using Domain;

namespace Bot.Api.Gateway
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
            Post("api/User/ActivateConfirmationCode&", );
        }

        public void Dispose()
        {
            // nothing here yet
        }
    }
}
