using System;
using System.Threading.Tasks;
using Domain;

namespace Bot.Service
{
    public interface IUserService
    {
        Task<bool> IsUserRegisteredAsync(UserBotChannel user);
    }
}
