using Labs.Pubquiz.Domain.Common.Commands;

namespace Labs.Pubquiz.Domain
{
    public interface IDispatcher
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}