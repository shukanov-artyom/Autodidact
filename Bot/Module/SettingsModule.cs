using System.Configuration;
using Autofac;
using Bot.Api.Gateway;

namespace Bot.Module
{
    public class SettingsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<ApiSettings>(CreateApiSettings);
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
    }
}