namespace Bot.Dialogs
{
    using System;
    using System.Threading.Tasks;
    using Bot.CQRS;
    using Bot.CQRS.Dto;
    using Bot.Cqrs.Dto;
    using Bot.Utils;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Connector;

    [Serializable]
    public class AcceptConfirmationCodeDialog : IDialog<object>
    {
        private readonly string channelType;
        private readonly string channelUserId;

        public AcceptConfirmationCodeDialog(
            string channelType,
            string channelUserId)
        {
            this.channelType = channelType;
            this.channelUserId = channelUserId;
        }

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
            if (!code.HasValue)
            {
                await context.PostAsync("This does not look like confirmation code.");
                await context.PostAsync(
                    "Please provide me a confirmation code to complete registration");
                context.Wait(MessageReceivedAsync);
            }
            else
            {
                if (await IsUsersValidConfirmationCodeAsync(
                    channelType,
                    channelUserId,
                    code.Value))
                {
                    await ActivateConfirmationCodeAsync(
                        channelType,
                        channelUserId,
                        code.Value);
                    await context.PostAsync(
                    "Thanks! Now you are registered and we can continue.");
                    context.Done(code.Value);
                }
                else
                {
                    await context.PostAsync("This is not your confirmation code!");
                    await context.PostAsync("Please check everything and try again.");
                }
            }
        }

        private async Task<bool> IsUsersValidConfirmationCodeAsync(
            string channelType,
            string channelUserId,
            Guid code)
        {
            return await DomainGateway.QueryAsync(
                new CheckConfirmationCodeQuery(channelType, channelUserId, code));
        }

        private async Task ActivateConfirmationCodeAsync(
            string channelType,
            string channelUserId,
            Guid code)
        {
            var command = new ActivateConfirmationCodeCommand(
                channelType,
                channelUserId,
                code);
            await DomainGateway.RunAsync(command);
        }
    }
}