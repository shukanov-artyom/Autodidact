using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot.Dialogs
{
    [Serializable]
    public class RegistrationDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        protected virtual async Task MessageReceivedAsync(
            IDialogContext context,
            IAwaitable<IMessageActivity> result)
        {
            throw new NotImplementedException();
        }
    }
}