using System;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Questions.Entities
{
    /// <summary>
    ///   An option to a question for any quiz.
    /// </summary>
    public class Answer : Entity<Answer>
    {
        public int Index { get; set; }

        public string Text { get; set; }

        public Guid QuestionId { get; set; }

        public Question Question { get; set; }

        public bool Correct { get; set; }
    }
}