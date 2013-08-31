using Labs.Pubquiz.Domain.Common.Adapters;
using Labs.Pubquiz.Domain.Common.Exceptions;
using Labs.Pubquiz.Domain.Common.Handlers;
using Labs.Pubquiz.Domain.Questions.Commands;
using Labs.Pubquiz.Domain.Questions.Entities;

namespace Labs.Pubquiz.Domain.Questions.Handlers
{
    public class QuestionHandler
        : ICommandHandler<AddQuestionCommand>,
          ICommandHandler<RemoveQuestionCommand>,
          ICommandHandler<ModifyQuestionCommand>
    {
        public QuestionHandler(IStorage context)
        {
            Context = context;
        }

        protected IStorage Context { get; set; }

        public void Handle(AddQuestionCommand command)
        {
            var question = Context.Find<Question>(command.QuestionId);
            if (question != null)
                throw new BusinessException("The provided Question ({0}) already exists in data store.", command.QuestionId);

            question = new Question
                           {
                               Id = command.QuestionId,
                               Text = command.Text,
                           };

            Context.Add(question);
        }

        public void Handle(RemoveQuestionCommand command)
        {
            var question = Context.Find<Tag>(command.QuestionId);
            if (question == null)
                throw new BusinessException("The provided Question ({0}) does not exists in data store.", command.QuestionId);

            Context.Remove(question);
        }

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