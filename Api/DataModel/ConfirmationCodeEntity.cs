using System;

namespace Api.DataModel
{
    public class ConfirmationCodeEntity
    {
        /// <summary>
        /// User ID to confirm with code.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Channel user to confirm code.
        /// </summary>
        public long ChannelUserId { get; set; }

        /// <summary>
        /// Confirmation code itself.
        /// </summary>
        public string ConfirmationCode { get; set; }

        /// <summary>
        /// Channel USer navigation property.
        /// </summary>
        public ChannelUserEntity ChannelUser { get; set; }
    }
}
