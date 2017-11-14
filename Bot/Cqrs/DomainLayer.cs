using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Autofac;
using Bot.CQRS.Command;
using Bot.CQRS.Query;

namespace Bot.CQRS
{
    /// <summary>
    /// Static facade for domain layer to access from bots' dialogs.
    /// </summary>
    public static class DomainGateway
    {
        private static ILifetimeScope container;

        public static void SetContainer(ILifetimeScope box)
        {
            container = box;
        }

        public static async Task<TQueryResult> QueryAsync<TQueryResult>(
            IQuery<TQueryResult> query)
        {
            InjectProperties(query);
            return await Task.Run(() => query.Run());
        }

        public static async Task RunAsync<TCommand>(
            TCommand command)
            where TCommand : ICommand
        {
            InjectProperties(command);
            await Task.Run(() => command.Execute());
        }

        private static void InjectProperties(object target)
        {
            try
            {
                container.InjectProperties(target);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                throw;
            }
        }
    }
}