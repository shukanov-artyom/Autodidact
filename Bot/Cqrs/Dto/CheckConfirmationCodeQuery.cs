using System;
using Bot.CQRS.Query;

namespace Bot.CQRS.Dto
{
    public class CheckConfirmationCodeQuery : IQuery<bool>
    {
        public CheckConfirmationCodeQuery(Guid code)
        {
            ConfirmationCode = code;
        }

        public Guid ConfirmationCode { get; }

        public bool Run()
        {
            throw new NotImplementedException();
        }
    }
}