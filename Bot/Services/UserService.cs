using System;
using Api.Interfaces;
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

        public UserRegistrationStatus IsUserRegistered(UserBotChannel user)
        {
            using (var client = new ApiClient(apiSettings))
            {
                return client.IsUserRegistered(user);
            }
        }
    }
}