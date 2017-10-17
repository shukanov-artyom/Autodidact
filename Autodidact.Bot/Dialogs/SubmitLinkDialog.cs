using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot.Dialogs
{
    public class SubmitLinkDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            throw new NotImplementedException();
        }

        private async Task ProcessMessageAsync(
            IDialogContext context,
            IAwaitable<IMessageActivity> activity)
        {
            var message = await activity;
        }
    }
}