using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Games.Entities
{
    /// <summary>
    ///   A division of a contest such as a quiz game.
    /// </summary>
    public class Round : Entity<Round>
    {
        public string Name { get; set; }

        public Guid QuizId { get; set; }

        public Quiz Quiz { get; set; }

        public IList<QuizQuestion> Questions { get; set; }

        public bool Active { get; set; }
    }
}