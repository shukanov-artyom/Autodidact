using System;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IConfirmationCodeService
    {
        string GetConfirmationCode(long userId, string botChannelType, string userChannelId);

        Task ActivateConfirmationCodeAsync(string channelType, string channeluserId, Guid code);

        bool IsValidUsersConfirmationCode(string channelType, string channeluserId, Guid code);
    }
}
