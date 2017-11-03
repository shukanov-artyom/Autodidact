using System;
using Api.Services;
using Autofac;

namespace Api.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ConfirmationCodeService>()
                .As<IConfirmationCodeService>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
