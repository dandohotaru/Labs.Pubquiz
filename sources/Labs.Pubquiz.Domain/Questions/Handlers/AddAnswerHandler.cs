using System.Linq;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Adapters;
using Labs.Pubquiz.Domain.Common.Exceptions;
using Labs.Pubquiz.Domain.Common.Handlers;
using Labs.Pubquiz.Domain.Questions.Entities;

namespace Labs.Pubquiz.Domain.Questions.Handlers
{
    public class AddAnswerHandler : ICommandHandler<AddAnswerCommand>
    {
        public AddAnswerHandler(IStorage context)
        {
            Context = context;
        }

        protected IStorage Context { get; set; }

        public void Handle(AddAnswerCommand command)
        {
            var answer = Context.Find<Answer>(command.AnswerId);
            if (answer != null)
                throw new BusinessException("The provided Answer ({0}) already exists in data store.", command.AnswerId);

            var index = Context
                .Query<Question>()
                .Where(p => p.Id == command.QuestionId)
                .SelectMany(p => p.Answers)
                .Max(p => p.Index);

            answer = new Answer
                {
                    Id = command.AnswerId,
                    QuestionId = command.QuestionId,
                    Text = command.Text,
                    Correct = command.Correct,
                    Index = index + 1,
                };

            Context.Add(answer);
        }
    }
}