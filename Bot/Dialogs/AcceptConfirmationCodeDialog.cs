using System;
using System.Threading.Tasks;
using Bot.Utils;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot.Dialogs
{
    [Serializable]
    public class AcceptConfirmationCodeDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        protected virtual async Task MessageReceivedAsync(
            IDialogContext context,
            IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            ConfirmationCodeParser parser =
                new ConfirmationCodeParser(message.Text);
            Guid? code = parser.Parse();
            if (code == null)
            {
                await context.PostAsync("This does not look like confirmation code.");
                await context.PostAsync(
                    "Please provide me a confirmation code to complete registration");
                context.Wait(MessageReceivedAsync);
            }
            else
            {
                await context.PostAsync(
                    "Thanks! Now you are registered and we can continue.");
                context.Done(code.Value);
            }
        }
    }
}