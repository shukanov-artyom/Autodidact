using System;
using System.Threading.Tasks;
using Bot.CQRS;
using Bot.Cqrs.Dto;
using Bot.Models;
using Bot.Utils;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot.Dialogs
{
    /// <summary>
    /// This dialog goes through registration and accepts confirmation code from a user.
    /// </summary>
    [Serializable]
    public class RegistrationDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(
            IDialogContext context,
            IAwaitable<IMessageActivity> result)
        {
            IMessageActivity message = await result;
            await context.PostAsync("Looks like you are not registered. Let's do it now.");
            await context.PostAsync(
                $"Please use this link to register: {await GetRegistrationLinkAsync(message)}");
            await context.PostAsync(
                "When you will get a confirmation code, please give it to me to finish registration.");
            context.Done("I'm done");
        }

        private async Task<string> GetRegistrationLinkAsync(IMessageActivity message)
        {
            var user = new ChannelUserInfo(message);
            var query = new GetRegistrationLinkQuery(user);
            return await DomainGateway.QueryAsync(query);
        }
    }
}