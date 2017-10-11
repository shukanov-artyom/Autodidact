using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HelloBot.Dialogs
{
    [Serializable]
    public class EchoDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(
            IDialogContext context,
            IAwaitable<object> result)
        {
            var activity = await result as Activity;
            await context.PostAsync($"Looks like you have just said {activity.Text}");
            context.Wait(MessageReceivedAsync);
        }
    }
}