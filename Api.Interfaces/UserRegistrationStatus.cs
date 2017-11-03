using System;

namespace Api.Interfaces
{
    public enum UserRegistrationStatus
    {
        NotRegistered = 0,

        AwaitingConfirmationCode = 1,

        Registered = 2
    }
}
