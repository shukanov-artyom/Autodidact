using System;

namespace Bot.Services
{
    public interface IConfirmationCodeService
    {
        bool IsValidUsersConfirmationCode(
            string channelType,
            string channelUserId,
            Guid code);

        void ActivateConfirmationCode(Guid code);
    }
}
