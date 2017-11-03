using System;

namespace Api.Services
{
    public interface IConfirmationCodeService
    {
        string GetConfirmationCode(long userId, string botChannelType, string userChannelId);
    }
}
