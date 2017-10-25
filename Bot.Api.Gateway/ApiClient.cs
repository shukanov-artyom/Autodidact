using System;
using Domain;

namespace Bot.Api.Gateway
{
    public class ApiClient : WebServiceClientBase, IDisposable
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

        public void Dispose()
        {
            // nothing here yet
        }
    }
}
