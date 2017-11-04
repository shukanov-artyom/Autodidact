using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot.Dialogs
{
    public class AcceptConfirmationCodeDialog : IDialog
    {
        private readonly string stsEndpoint;

        public AcceptConfirmationCodeDialog(string stsEndpoint)
        {
            this.stsEndpoint = stsEndpoint;
        }

        public Task StartAsync(IDialogContext context)
        {
            throw new NotImplementedException();
        }

        protected virtual async Task MessageReceivedAsync(
            IDialogContext context,
            IAwaitable<IMessageActivity> result)
        {
            throw new NotImplementedException();
        }
    }
}