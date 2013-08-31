using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Games.Entities
{
    /// <summary>
    ///   A matter forming the basis of a problem requiring resolution.
    /// </summary>
    public class Question : Entity
    {
        public Guid ReferenceId { get; set; }

        public Guid RoundId { get; set; }

        public Round Round { get; set; }

        public IList<Answer> Answers { get; set; }

        public IList<Pick> Picks { get; set; }

        public bool Active { get; set; }
    }
}