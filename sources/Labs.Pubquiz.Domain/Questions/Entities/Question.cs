using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Pubquiz.Domain.Common.Entities;
using Labs.Pubquiz.Domain.Common.Exceptions;

namespace Labs.Pubquiz.Domain.Questions.Entities
{
    /// <summary>
    ///   A matter forming the basis of a problem requiring resolution for any quiz.
    /// </summary>
    public class Question : Entity<Question>
    {
        public string Text { get; protected set; }

        public IList<Answer> Answers { get; protected set; }

        public IList<Tag> Tags { get; protected set; }

        public Question ApplyText(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new BusinessException("The question text is required.");
            Text = text;
            return this;
        }

        public Question AddAnswer(Guid answerId, string answerText, bool answerCorrect)
        {
            if (Answers == null)
                Answers = new List<Answer>();

            if (Answers.Any(p => p.Id == answerId))
                throw new BusinessException("The answer ({0}) is already linked with the question.", answerId);

            var index = Answers.Any() ? Answers.Max(p => p.Index) + 1 : 1;
            var answer = new Answer()
                .WithId(answerId)
                .ApplyText(answerText)
                .ApplyIndex(index)
                .ApplyCorrect(answerCorrect);

            Answers.Add(answer);
            return this;
        }
    }
}