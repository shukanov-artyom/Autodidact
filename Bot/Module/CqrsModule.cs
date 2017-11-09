using System;
using Autofac;
using Bot.CQRS.Dto;
using Bot.CQRS.Query;
using Bot.CQRS.Command;

namespace Bot.Module
{
    public class CqrsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CheckConfirmationCodeQuery).Assembly;
            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IQuery<>));
            builder.RegisterAssemblyTypes(assembly).As<ICommand>();
        }
    }
}