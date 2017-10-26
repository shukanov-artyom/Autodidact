using System;

namespace Api.DataModel
{
    public class ChannelUserEntity
    {
        /// <summary>
        /// Reference to User Id in STS database.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Skype / slack / telegram etc
        /// </summary>
        public string ChannelType { get; set; }

        /// <summary>
        /// UniqueId of a user in his channel.
        /// </summary>
        public string ChannelUserId { get; set; }
    }
}
