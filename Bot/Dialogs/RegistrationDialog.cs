using System;
using System.Threading.Tasks;
using Bot.Models;
using Bot.Settings;
using Bot.Utils;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot.Dialogs
{
    [Serializable]
    public class RegistrationDialog : IDialog<object>
    {
        private readonly string stsEndpoint;

        public RegistrationDialog(string stsEndpoint)
        {
            this.stsEndpoint = stsEndpoint;
        }

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Looks like you are not registered. Let's do it now.");
            context.Wait(MessageReceivedAsync);
        }

        protected virtual async Task MessageReceivedAsync(
            IDialogContext context,
            IAwaitable<IMessageActivity> result)
        {
            IMessageActivity message = await result;
            await context.PostAsync(
                $"Please use this link to register: {GetRegistrationLink(message)}");
        }

        private string GetRegistrationLink(IMessageActivity message)
        {
            ChannelUserInfo user = new ChannelUserInfo(message);
            string securityTokenServiceUrl = stsEndpoint;
            return new RegistrationLinkFactory(securityTokenServiceUrl)
                .GenerateLink(user);
        }
    }
}