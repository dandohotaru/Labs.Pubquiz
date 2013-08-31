using System;
using Labs.Pubquiz.Domain.Common.Entities;
using Labs.Pubquiz.Domain.Common.Exceptions;

namespace Labs.Pubquiz.Domain.Questions.Entities
{
    /// <summary>
    ///   An option to a question for any quiz.
    /// </summary>
    public class Answer : Entity<Answer>
    {
        public int Index { get; protected set; }

        public string Text { get; protected set; }

        public Guid QuestionId { get; protected set; }

        public Question Question { get; protected set; }

        public bool Correct { get; protected set; }

        public Answer ForQuestion(Guid questionId)
        {
            if (questionId == default(Guid))
                throw new BusinessException("The question is required.");
            QuestionId = questionId;
            return this;
        }

        public Answer ApplyText(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new BusinessException("The answer text is required.");
            Text = text;
            return this;
        }

        public Answer ApplyIndex(int index)
        {
            if (index <= 0)
                throw new BusinessException("The answer index needs to be a positive number.");
            Index = index;
            return this;
        }

        public Answer ApplyCorrect(bool correct)
        {
            Correct = correct;
            return this;
        }
    }
}