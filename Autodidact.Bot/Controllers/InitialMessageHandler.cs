using System;
using System.Threading.Tasks;
using Bot.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot.Controllers
{
    public class InitialMessageHandler
    {
        private readonly IMessageActivity message;

        public InitialMessageHandler(IMessageActivity message)
        {
            this.message = message;
        }

        public async Task HandleAsync()
        {
            // do we have a registered user here?
            var data = message.ChannelData;
            string channelId = message.ChannelId;
            string userId = message.From.Id;
            ChannelAccount acc = message.From;
            string msg = message.Text.ToLower();
            if (msg.StartsWith("http://") ||
                msg.StartsWith("https://"))
            {
                // this is a link!
            }
            else
            {
                // this is not a link
            }
            await Conversation.SendAsync(message, () => new RootDialog());
        }
    }
}