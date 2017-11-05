using System;

namespace Bot.Utils
{
    public class ConfirmationCodeParser
    {
        public ConfirmationCodeParser(string messageText)
        {
            MessageText = messageText;
        }

        private string MessageText
        {
            get;
        }

        public Guid? Parse()
        {
            Guid result;
            if (!Guid.TryParse(MessageText, out result))
            {
                return null;
            }
            return result;
        }
    }
}