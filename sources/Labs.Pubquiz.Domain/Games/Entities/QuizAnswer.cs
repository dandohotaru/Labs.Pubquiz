using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Games.Entities
{
    /// <summary>
    ///   An option to a question in a quiz.
    /// </summary>
    public class QuizAnswer : Entity<QuizAnswer>
    {
        public Guid ReferenceId { get; set; }

        public Guid QuestionId { get; set; }

        public QuizQuestion Question { get; set; }

        public IList<Pick> Picks { get; set; }
    }
}