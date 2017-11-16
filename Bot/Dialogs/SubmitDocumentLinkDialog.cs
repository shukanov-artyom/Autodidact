using System;
using System.Threading.Tasks;
using Bot.Models;
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
            throw new NotImplementedException();
        }
    }
}