namespace Bot.Cqrs
{
    public interface ICommand
    {
        void Execute();
    }
}