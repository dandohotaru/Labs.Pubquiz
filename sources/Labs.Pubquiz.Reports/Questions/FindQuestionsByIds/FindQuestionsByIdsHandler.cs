using System;
using System.Linq;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Questions.Entities;
using Labs.Pubquiz.Reports.Common;

namespace Labs.Pubquiz.Reports.Questions.FindQuestionsByIds
{
    public class FindQuestionsByIdsHandler
        : IQueryHandler<FindQuestionsByIdsQuery, FindQuestionsByIdsResult>
    {
        public FindQuestionsByIdsHandler(IStorage context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            Context = context;
        }

        protected IStorage Context { get; private set; }

        public FindQuestionsByIdsResult Handle(FindQuestionsByIdsQuery request)
        {
            var questions = from question in Context.Query<Question>()
                            where request.QuestionIds.Contains(question.Id)
                            select new QuestionInfo
                                       {
                                           Id = question.Id,
                                           Text = question.Text,
                                       };

            var answers = from answer in Context.Query<Answer>()
                          where request.QuestionIds.Contains(answer.QuestionId)
                          select new AnswerInfo
                                     {
                                         Id = answer.Id,
                                         QuestionId = answer.QuestionId,
                                         Correct = answer.Correct,
                                         Text = answer.Text,
                                     };

            return new FindQuestionsByIdsResult
                       {
                           Questions = questions.ToList(),
                           Answers = answers.ToList(),
                       };
        }
    }
}