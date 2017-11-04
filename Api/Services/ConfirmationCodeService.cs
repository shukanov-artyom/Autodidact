using System;
using Api.DataModel;

namespace Api.Services
{
    public class ConfirmationCodeService : IConfirmationCodeService, IDisposable
    {
        private readonly ApiDatabaseContext databaseContext;

        public ConfirmationCodeService(ApiDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public string GetConfirmationCode(
            long userId,
            string botChannelType,
            string userChannelId)
        {
            Guid guid = Guid.NewGuid(); // let it be confirmation code

            // create a channel user
            ChannelUserEntity channelUser = new ChannelUserEntity()
            {
                ChannelType = botChannelType,
                ChannelUserId = userChannelId
            };
            databaseContext.ChannelUsers.Add(channelUser);
            databaseContext.SaveChanges();
            // create a confirmation code for him
            var confirmationCodeEntity = new ConfirmationCodeEntity()
            {
                ConfirmationCode = guid.ToString(),
                ChannelUserId = channelUser.Id,
                UserId = userId
            };
            // return a confirmation code
            databaseContext.ConfirmationCodes.Add(confirmationCodeEntity);
            databaseContext.SaveChanges();
            return confirmationCodeEntity.ConfirmationCode;
        }

        public void Dispose()
        {
            if (databaseContext != null)
            {
                databaseContext.Dispose();
            }
        }
    }
}
