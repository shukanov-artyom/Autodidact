using System;
using System.Threading;
using System.Threading.Tasks;
using Bot.Models;
using Bot.Utils;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(
            IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        protected virtual async Task MessageReceivedAsync(
            IDialogContext context,
            IAwaitable<IMessageActivity> result)
        {
            var msg = await result;
            if (new LinkDetector(msg.Text).IsLink())
            {
                await context.Forward(
                    new SubmitLinkDialog(),
                    RestartProcessing,
                    msg,
                    CancellationToken.None);
            }
            else
            {
                PromptDialog.Choice(
                    context,
                    OnOptionSelected,
                    new ApplicationOptions(),
                    "What to start with?");
            }
            // TODO : Continue messages processing
        }

        private async Task OnOptionSelected(
            IDialogContext context,
            IAwaitable<string> selectionResult)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task RestartProcessing(
            IDialogContext context,
            IAwaitable<int> awaitable)
        {
            var message = await awaitable;
            await context.PostAsync("Thanks!");
            context.Wait(MessageReceivedAsync);
        }
    }
}