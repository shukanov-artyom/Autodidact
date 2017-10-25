using System;
using Bot.Api.Gateway;
using Domain;

namespace Bot.Services
{
    public class UserService : IUserService
    {
        private readonly ApiSettings apiSettings;

        public UserService(ApiSettings apiSettings)
        {
            this.apiSettings = apiSettings;
        }

        public bool IsUserRegistered(UserBotChannel user)
        {
            using (var client = new ApiClient(apiSettings))
            {
                return client.IsUserRegistered(user);
            }
        }
    }
}