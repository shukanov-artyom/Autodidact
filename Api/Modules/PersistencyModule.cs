using System;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Api.DataModel;

namespace Api.Modules
{
    public class PersistencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ApiDatabaseContext>()
                .As<DbContext>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
