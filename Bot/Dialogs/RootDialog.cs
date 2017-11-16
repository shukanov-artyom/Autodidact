using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Interfaces;
using Bot.CQRS;
using Bot.Cqrs.Dto;
using Bot.Models;
using Domain;
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
            var message = await result;
            var registrationStatus = await IsUserRegisteredAsync(message);
            if (registrationStatus == UserRegistrationStatus.NotRegistered)
            {
                await context.Forward(
                    new RegistrationDialog(),
                    Continuation,
                    message,
                    CancellationToken.None);
            }
            else if (registrationStatus == UserRegistrationStatus.AwaitingConfirmationCode)
            {
                var info = new ChannelUserInfo(message);
                await context.Forward(
                    new AcceptConfirmationCodeDialog(
                        info.ChannelId,
                        info.UserId),
                    Continuation,
                    message,
                    CancellationToken.None);
            }
            else if (registrationStatus == UserRegistrationStatus.Registered)
            {
                var info = new ChannelUserInfo(message);
                await context.Forward(
                    new SubmitDocumentLinkDialog(info),
                    Continuation,
                    message,
                    CancellationToken.None);
            }
            else
            {
                throw new InvalidOperationException(
                    "Unrecognized user registration state.");
            }
        }

        private async Task<UserRegistrationStatus> IsUserRegisteredAsync(
            IMessageActivity activity)
        {
            ChannelUserInfo userInfo = new ChannelUserInfo(activity);
            var botChannel = new UserBotChannel
            {
                ChannelType = userInfo.ChannelId,
                ChannelUserId = userInfo.UserId
            };
            var query = new CheckUserRegisteredQuery(botChannel);
            var status = await DomainGateway.QueryAsync(query);
            return status;
        }

        private async Task Continuation(
            IDialogContext context,
            IAwaitable<object> result)
        {
            context.Wait(MessageReceivedAsync);
        }
    }
}