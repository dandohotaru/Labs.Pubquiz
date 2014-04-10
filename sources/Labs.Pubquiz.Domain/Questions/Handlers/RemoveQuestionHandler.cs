using System;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Adapters;
using Labs.Pubquiz.Domain.Common.Exceptions;
using Labs.Pubquiz.Domain.Common.Handlers;
using Labs.Pubquiz.Domain.Questions.Entities;

namespace Labs.Pubquiz.Domain.Questions.Handlers
{
    public class RemoveQuestionHandler : ICommandHandler<RemoveQuestionCommand>
    {
        public RemoveQuestionHandler(IStorage context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            Context = context;
        }

        protected IStorage Context { get; private set; }

        public void Handle(RemoveQuestionCommand command)
        {
            var question = Context.Find<Tag>(command.QuestionId);
            if (question == null)
                throw new BusinessException("The provided Question ({0}) does not exist in data store.",
                                            command.QuestionId);

            Context.Remove(question);
        }
    }
}