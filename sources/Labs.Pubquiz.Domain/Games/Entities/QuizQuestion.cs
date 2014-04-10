using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Games.Entities
{
    /// <summary>
    ///   A matter forming the basis of a problem requiring resolution.
    /// </summary>
    public class QuizQuestion : Entity<QuizQuestion>
    {
        public Guid ReferenceId { get; set; }

        public Guid RoundId { get; set; }

        public Round Round { get; set; }

        public IList<QuizAnswer> Answers { get; set; }

        public IList<Pick> Picks { get; set; }

        public bool Active { get; set; }
    }
}