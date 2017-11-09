using System;
using Api.Interfaces;
using Bot.CQRS.Query;
using Bot.Services;
using Domain;

namespace Bot.Cqrs.Dto
{
    public class CheckUserRegisteredQuery : IQuery<UserRegistrationStatus>
    {
        private readonly UserBotChannel channel;

        public CheckUserRegisteredQuery(UserBotChannel channel)
        {
            this.channel = channel;
        }

        public IUserService UserService { get; set; }

        public UserRegistrationStatus Run()
        {
            return UserService.IsUserRegistered(channel);
        }
    }
}