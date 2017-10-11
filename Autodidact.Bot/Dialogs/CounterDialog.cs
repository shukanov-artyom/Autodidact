using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HelloBot.Dialogs
{
    [Serializable]
    public class CounterDialog : IDialog<object>
    {
        private int counter = 1;

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
            if (activity.Text == "reset")
            {
                PromptDialog.Confirm(
                    context,
                    AfterResetAsync,
                    "Are you sure you want to reset the count?",
                    "Didn't get that!",
                    promptStyle: PromptStyle.None);
            }
            else
            {
                await context.PostAsync($"{this.counter++}: Seems you said: {activity.Text}");
                context.Wait(MessageReceivedAsync);
            }
        }

        private async Task AfterResetAsync(
            IDialogContext context,
            IAwaitable<bool> argument)
        {
            var confirm = await argument;
            if (confirm)
            {
                this.counter = 1;
                await context.PostAsync("Reset count");
            }
            else
            {
                await context.PostAsync("Did not reset count");
            }
            context.Wait(MessageReceivedAsync);
        }
    }
}