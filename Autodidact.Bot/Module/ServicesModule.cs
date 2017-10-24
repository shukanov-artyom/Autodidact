using System;
using Autofac;
using Bot.Service;

namespace Bot.Module
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}