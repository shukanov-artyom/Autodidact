using System;
using Domain;

namespace Bot.Services
{
    public interface IUserService
    {
        bool IsUserRegistered(UserBotChannel user);
    }
}
