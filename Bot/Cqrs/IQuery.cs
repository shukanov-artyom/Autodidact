namespace Bot.Cqrs
{
    public interface IQuery<out TQueryResult>
    {
        TQueryResult Run();
    }
}
