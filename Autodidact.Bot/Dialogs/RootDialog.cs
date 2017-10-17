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
            await context.SayAsync("Hi user!");
            context.Wait(MessageReceivedAsync);
        }

        protected virtual async Task MessageReceivedAsync(
            IDialogContext context,
            IAwaitable<IMessageActivity> result)
        {
            IMessageActivity msg = await result;
            await RecognizeUserAsync(new ChannelUserInfo(msg));
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

        private async Task RecognizeUserAsync(ChannelUserInfo userInfo)
        {
            // TODO : query API asynchronously
            // TODO : and clarify whether we already know this user.
        }

        private async Task RestartProcessing(
            IDialogContext context,
            IAwaitable<object> awaitable)
        {
            context.Wait(MessageReceivedAsync);
        }
    }
}