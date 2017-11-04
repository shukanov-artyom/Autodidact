using System;
using Api.DataModel;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Api.Modules
{
    public class PersistencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ApiDatabaseContext>()
                .As<DbContext>()
                .InstancePerDependency();
            base.Load(builder);
        }
    }
}
