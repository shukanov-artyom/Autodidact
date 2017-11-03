using System;
using Api.Interfaces;
using Domain;

namespace Bot.Services
{
    public interface IUserService
    {
        UserRegistrationStatus IsUserRegistered(UserBotChannel user);
    }
}
