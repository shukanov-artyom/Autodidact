using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot.Dialogs
{
    [Serializable]
    public class SubmitLinkDialog : IDialog<int>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.SayAsync("Entering SubmitLinkDialog");
            context.Wait(ProcessMessageAsync);
        }

        private async Task ProcessMessageAsync(
            IDialogContext context,
            IAwaitable<IMessageActivity> activity)
        {
            var link = await activity;
            await context.PostAsync($"Soon i'll be ready to register your link {link}, patience please!");
            context.Done(100);
        }
    }
}