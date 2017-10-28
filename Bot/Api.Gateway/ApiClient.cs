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

        public bool IsUserRegistered(UserBotChannel user)
        {
            try
            {
                return Post<bool>("api/User/IsRegistered", user);
            }
            catch (Exception e)
            {
                string r = e.ToString();
                throw;
            }
        }

        public void SetConfirmationCodeForUser(long userId, string confirmationCode)
        {
            throw new NotImplementedException();
        }

        public void SendConfirmationCode(UserBotChannel channelUser, string confirmationCode)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // nothing here yet
        }
    }
}
