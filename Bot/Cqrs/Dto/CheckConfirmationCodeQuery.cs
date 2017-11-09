using System;
using Bot.CQRS.Query;
using Bot.Services;

namespace Bot.CQRS.Dto
{
    public class CheckConfirmationCodeQuery : IQuery<bool>
    {
        private readonly Guid code;

        private readonly string channelType;
        private readonly string channelUserId;

        public CheckConfirmationCodeQuery(
            string channelType,
            string channelUserId,
            Guid code)
        {
            this.channelType = channelType;
            this.channelUserId = channelUserId;
            this.code = code;
        }

        public Guid ConfirmationCode { get; }

        public IConfirmationCodeService ConfirmationCodeService { get; set; }

        public bool Run()
        {
            return ConfirmationCodeService.IsValidUsersConfirmationCode(
                channelType,
                channelUserId,
                code);
        }
    }
}