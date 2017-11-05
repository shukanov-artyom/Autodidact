using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Api.Interfaces;
using Bot.Dialogs;
using Bot.Models;
using Bot.Services;
using Bot.Settings;
using Bot.Utils;
using Domain;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot.Controllers
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private readonly IUserService userService;
        private readonly SecurityTokenServiceSettings tokenServerSettings;

        public MessagesController(
            IUserService userService,
            SecurityTokenServiceSettings tokenServerSettings)
        {
            this.userService = userService;
            this.tokenServerSettings = tokenServerSettings;
        }

        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                var message = activity as IMessageActivity;
                UserRegistrationStatus registrationStatus = IsUserRegistered(message);
                if (registrationStatus == UserRegistrationStatus.NotRegistered)
                {
                    string endpoint = tokenServerSettings.EndpointAddress;
                    await Conversation.SendAsync(
                        message,
                        () => new RegistrationDialog(endpoint));
                }
                else if (registrationStatus == UserRegistrationStatus.AwaitingConfirmationCode)
                {
                    await Conversation.SendAsync(
                        message,
                        () => new AcceptConfirmationCodeDialog());
                }
                else
                {
                    await Conversation.SendAsync(
                        activity,
                        () => new RootDialog());
                }
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private void HandleSystemMessage(Activity message)
        {
            new SystemMessageHandler().Handle(message);
        }

        private UserRegistrationStatus IsUserRegistered(
            IMessageActivity activity)
        {
            ChannelUserInfo userInfo = new ChannelUserInfo(activity);
            var botChannel = new UserBotChannel
            {
                ChannelType = userInfo.ChannelId,
                ChannelUserId = userInfo.UserId
            };
            return userService.IsUserRegistered(botChannel);
        }
    }
}