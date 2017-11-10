using System;
using Bot.CQRS.Command;
using Bot.Services;

namespace Bot.Cqrs.Dto
{
    public class ActivateConfirmationCodeCommand : ICommand
    {
        private readonly Action action;

        public ActivateConfirmationCodeCommand(
            string channelType,
            string channelUserId,
            Guid code)
        {
            action = () => ConfirmationCodeService
                .ActivateConfirmationCode(channelType, channelUserId, code);
        }

        public IConfirmationCodeService ConfirmationCodeService { get; set; }

        public void Execute()
        {
            action.Invoke();
        }
    }
}