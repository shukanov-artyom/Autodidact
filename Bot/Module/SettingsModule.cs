using System;
using System.Configuration;
using Autofac;
using Bot.Api.Gateway;
using Bot.Settings;

namespace Bot.Module
{
    public class SettingsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(CreateApiSettings);
            builder.Register(CreateStsSettings);
        }

        private ApiSettings CreateApiSettings(IComponentContext context)
        {
            string apiEndpoint =
                ConfigurationManager.AppSettings["ApiEndpoint"];
            return new ApiSettings()
            {
                ApiEndpointAddress = apiEndpoint
            };
        }

        private SecurityTokenServiceSettings CreateStsSettings(
            IComponentContext context)
        {
            string stsEndpoint =
                ConfigurationManager.AppSettings["ApiEndpoint"];
            if (string.IsNullOrEmpty(stsEndpoint))
            {
                throw new InvalidOperationException(
                    "No Security Token Service address configured.");
            }
            return new SecurityTokenServiceSettings(stsEndpoint);
        }
    }
}