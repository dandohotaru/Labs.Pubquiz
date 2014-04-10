namespace Labs.Pubquiz.Domain.Common.Handlers
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}