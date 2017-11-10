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
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(
                        activity,
                        () => new RootDialog());
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
    }
}