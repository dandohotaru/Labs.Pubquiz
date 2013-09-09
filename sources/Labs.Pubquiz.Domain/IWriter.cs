using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain
{
    public interface IWriter
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}