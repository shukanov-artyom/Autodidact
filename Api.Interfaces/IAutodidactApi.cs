using System;
using Domain;

namespace Api.Interfaces
{
    public interface IAutodidactApi
    {
        /// <summary>
        /// Determines whether a User is already known to the system.
        /// It means that he is logged on STS.
        /// </summary>
        UserRegistrationStatus IsUserRegistered(UserBotChannel user);

        /// <summary>
        /// Creates and returns confirmation code for particular user and channel.
        /// </summary>
        string GetConfirmationCode(long userId, string channelId, string channelUserId);
    }
}
