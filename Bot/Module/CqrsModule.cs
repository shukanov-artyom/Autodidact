using System;
using Autofac;
using Bot.CQRS.Dto;

namespace Bot.Module
{
    public class CqrsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(CheckConfirmationCodeQuery).Assembly).AsImplementedInterfaces();
        }
    }
}