using System;

namespace Api.Interfaces
{
    [Serializable]
    public class ActivateConfirmationCodeDto
    {
        public ActivateConfirmationCodeDto(
            string channelType,
            string channelUserId,
            Guid code)
        {
            ChannelType = channelType;
            ChannelUserId = channelUserId;
            Code = code;
        }

        public string ChannelType { get; set; }

        public string ChannelUserId { get; set; }

        public Guid Code { get; set; }
    }
}
