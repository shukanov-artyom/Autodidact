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
        bool IsUserRegistered(UserBotChannel user);

        /// <summary>
        /// When user registeres using a link provided by a bot,
        /// This method is called by STS and then a user must supply code through bot.
        /// </summary>
        void SetConfirmationCodeForUser(long userId, string confirmationCode);

        /// <summary>
        /// Bot calls this method when user sends confirmation code.
        /// Api registers user and likns his channel to his user data.
        /// </summary>
        void SendConfirmationCode(UserBotChannel channelUser, string confirmationCode);
    }
}
