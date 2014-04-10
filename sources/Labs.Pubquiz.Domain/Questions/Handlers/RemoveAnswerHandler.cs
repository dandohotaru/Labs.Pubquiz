using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Adapters;
using Labs.Pubquiz.Domain.Common.Exceptions;
using Labs.Pubquiz.Domain.Common.Handlers;
using Labs.Pubquiz.Domain.Questions.Entities;

namespace Labs.Pubquiz.Domain.Questions.Handlers
{
    public class RemoveAnswerHandler : ICommandHandler<RemoveAnswerCommand>
    {
        public RemoveAnswerHandler(IStorage context)
        {
            Context = context;
        }

        protected IStorage Context { get; set; }

        public void Handle(RemoveAnswerCommand command)
        {
            var answer = Context.Find<Tag>(command.AnswerId);
            if (answer == null)
                throw new BusinessException("The provided Answer ({0}) does not exists in data store.", command.AnswerId);

            Context.Remove(answer);
        }
    }
}