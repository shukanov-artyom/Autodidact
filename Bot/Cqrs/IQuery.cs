using System;

namespace Bot.CQRS.Query
{
    public interface IQuery<out TQueryResult>
    {
        TQueryResult Run();
    }
}
