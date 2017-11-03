using System;

namespace Api.Interfaces
{
    [Serializable]
    public class UserConfirmationCodeInfoDto
    {
        public long UserId { get; set; }

        public string ChannelId { get; set; }

        public string ChannelUserId { get; set; }
    }
}
