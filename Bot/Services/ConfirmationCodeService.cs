using System;

namespace Bot.Services
{
    public class ConfirmationCodeService : IConfirmationCodeService
    {
        public void ActivateConfirmationCode(Guid code)
        {
            throw new NotImplementedException();
        }

        public bool IsValidUsersConfirmationCode(
            string channelType,
            string channelUserId,
            Guid code)
        {
            throw new NotImplementedException();
        }
    }
}