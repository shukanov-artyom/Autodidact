using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Bot.Dialogs;
using Bot.Models;
using Bot.Service;
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

        public MessagesController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                IMessageActivity message = activity as IMessageActivity;
                bool isRegisteredUser = await IsUserRegisteredAsync(message);
                if (isRegisteredUser)
                {
                    await Conversation.SendAsync(
                        activity,
                        () => new RootDialog());
                }
                else
                {
                    await Conversation.SendAsync(
                        activity,
                        () => new RegistrationDialog());
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

        private async Task<bool> IsUserRegisteredAsync(
            IMessageActivity activity)
        {
            ChannelUserInfo userInfo = new ChannelUserInfo(activity);
            var botChannel = new UserBotChannel
            {
                ChannelType = userInfo.ChannelId,
                ChannelUserId = userInfo.UserId
            };
            return await userService.IsUserRegisteredAsync(botChannel);
        }
    }
}