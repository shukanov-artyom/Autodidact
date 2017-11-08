using System;

namespace Bot.CQRS.Command
{
    public interface ICommand
    {
        void Execute();
    }
}