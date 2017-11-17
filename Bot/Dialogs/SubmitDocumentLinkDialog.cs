using System;
using System.Threading.Tasks;
using Bot.Models;
using Bot.Utils;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot.Dialogs
{
    public class SubmitDocumentLinkDialog : IDialog<object>
    {
        private readonly ChannelUserInfo userInfo;

        public SubmitDocumentLinkDialog(ChannelUserInfo userInfo)
        {
            this.userInfo = userInfo;
        }

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(
            IDialogContext context,
            IAwaitable<IMessageActivity> result)
        {
            IMessageActivity message = await result;
            string maybeLink = message.Text;
            LinkDetector linkDetector = new LinkDetector(maybeLink);
            if (linkDetector.IsLink())
            {
                // this is link!
                // let's determine what's up with this
                // Like "Did you read it already or planning to do?"
            }
        }
    }
}