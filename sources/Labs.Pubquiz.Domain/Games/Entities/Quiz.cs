using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Games.Entities
{
    /// <summary>
    ///   A form of competitive activity one played according to rules and decided by skills strengths or luck.
    /// </summary>
    public class Quiz : Entity<Quiz>
    {
        public string Name { get; set; }

        public Guid InitiatorId { get; set; }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }

        public IList<Round> Rounds { get; set; }

        public QuizStatus Status { get; set; }
    }
}