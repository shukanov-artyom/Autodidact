using System;

namespace Api.Services
{
    public class ConfirmationCodeService : IConfirmationCodeService
    {
        public string GetConfirmationCode(
            long userId,
            string botChannelType,
            string userChannelId)
        {
            throw new NotImplementedException();
        }
    }
}
