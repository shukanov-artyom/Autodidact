using System;

namespace Bot.Settings
{
    public class SecurityTokenServiceSettings
    {
        public SecurityTokenServiceSettings(string endpointAddress)
        {
            EndpointAddress = endpointAddress;
        }

        public string EndpointAddress
        {
            get;
        }
    }
}