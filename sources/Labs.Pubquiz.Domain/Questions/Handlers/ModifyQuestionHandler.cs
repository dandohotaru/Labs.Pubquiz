using System;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Adapters;
using Labs.Pubquiz.Domain.Common.Exceptions;
using Labs.Pubquiz.Domain.Common.Handlers;
using Labs.Pubquiz.Domain.Questions.Entities;

namespace Labs.Pubquiz.Domain.Questions.Handlers
{
    public class ModifyQuestionHandler : ICommandHandler<ModifyQuestionCommand>
    {
        public ModifyQuestionHandler(IStorage context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            Context = context;
        }

        protected IStorage Context { get; private set; }

        public void Handle(ModifyQuestionCommand command)
        {
            var question = Context.Find<Question>(command.QuestionId);
            if (question == null)
                throw new BusinessException("The provided Question ({0}) does not exists in data store.", command.QuestionId);

            question.Text = command.Text;

            Context.Add(question);
        }
    }
}