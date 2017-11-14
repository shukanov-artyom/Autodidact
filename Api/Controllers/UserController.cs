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
        //[ResponseCache(Duration = 120)] -- cannot use while registering user
        public async Task<UserRegistrationStatus> IsRegistered(
            [FromBody]UserBotChannel channel)
        {
            bool isChannelUserPresent =
                database.ChannelUsers.Any(cu =>
                    cu.ChannelType == channel.ChannelType &&
                    cu.ChannelUserId == channel.ChannelUserId);
            bool isUserConfirmationCodeSet =
                database.ConfirmationCodes.Any(
                    cc => cc.ChannelUser.ChannelUserId == channel.ChannelUserId
                          && cc.ChannelUser.ChannelType == channel.ChannelType);
            // if there is a channel user already without code, then registered
            if (isChannelUserPresent && !isUserConfirmationCodeSet)
            {
                return UserRegistrationStatus.Registered;
            }
            // If there is a ChannelUser, but there is also a confirmation code pending
            if (isChannelUserPresent && isUserConfirmationCodeSet)
            {
                return UserRegistrationStatus.AwaitingConfirmationCode;
            }
            // if no user and no confirmation code
            if (!isChannelUserPresent && !isUserConfirmationCodeSet)
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
                info.ChannelId,
                info.ChannelUserId);
        }

        [Route("api/User/ActivateConfirmationCode")]
        [HttpPost]
        public async Task ActivateConfirmationCode(
            [FromBody]ActivateConfirmationCodeDto dto)
        {
            await confirmationCodeService.ActivateConfirmationCodeAsync(
                dto.ChannelType,
                dto.ChannelUserId,
                dto.Code);
        }
    }
}