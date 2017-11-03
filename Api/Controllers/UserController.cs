using System;
using System.Linq;
using System.Threading.Tasks;
using Api.DataModel;
using Api.Interfaces;
using Api.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class UserController : Controller
    {
        private readonly ApiDatabaseContext database;
        private readonly IConfirmationCodeService confirmationCodeService;

        public UserController(
            ApiDatabaseContext database,
            IConfirmationCodeService confirmationCodeService)
        {
            this.database = database;
            this.confirmationCodeService = confirmationCodeService;
        }

        [Route("api/User/IsRegistered")]
        [HttpPost]
        [ResponseCache(Duration = 120)]
        public async Task<UserRegistrationStatus> IsRegistered(
            [FromBody]UserBotChannel channel)
        {
            UserRegistrationStatus result;
            // if there is a channel user already, then registered
            if (database.ChannelUsers.Any(cu =>
                cu.ChannelType == channel.ChannelType &&
                cu.ChannelUserId == channel.ChannelUserId))
            {
                return UserRegistrationStatus.Registered;
            }
            // If no records in ChannelUSer, but there is a confirmation code
            if (!database.ChannelUsers.Any(cu =>
                    cu.ChannelType == channel.ChannelType &&
                    cu.ChannelUserId == channel.ChannelUserId) &&
                database.ConfirmationCodes.Any(
                    cc => cc.ChannelUser.ChannelUserId == channel.ChannelUserId
                    && cc.ChannelUser.ChannelType == channel.ChannelType))
            {
                return UserRegistrationStatus.AwaitingConfirmationCode;
            }
            // if no user and no confirmation code
            if (!database.ChannelUsers.Any(cu =>
                    cu.ChannelType == channel.ChannelType &&
                    cu.ChannelUserId == channel.ChannelUserId) &&
                !database.ConfirmationCodes.Any(
                    cc => cc.ChannelUser.ChannelUserId == channel.ChannelUserId
                          && cc.ChannelUser.ChannelType == channel.ChannelType))
            {
                return UserRegistrationStatus.NotRegistered;
            }
            throw new InvalidOperationException();
        }

        [Route("api/User/ConfirmationCode")]
        [HttpPost]
        public async Task<string> ConfirmationCode(
            [FromBody]UserConfirmationCodeInfoDto info)
        {
            return confirmationCodeService.GetConfirmationCode(
                info.UserId,
                info.ChannelUserId,
                info.ChannelId);
        }
    }
}