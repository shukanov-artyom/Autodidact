using System;
using System.Threading.Tasks;
using Domain;

namespace Bot.Service
{
    public class UserService : IUserService
    {
        public async Task<bool> IsUserRegisteredAsync(UserBotChannel user)
        {
            throw new NotImplementedException();
        }
    }
}