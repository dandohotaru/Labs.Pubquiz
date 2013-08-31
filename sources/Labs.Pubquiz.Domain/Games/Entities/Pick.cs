using System;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Games.Entities
{
    /// <summary>
    ///   An act of selecting something from among a group of alternatives.
    /// </summary>
    public class Pick : Entity
    {
        public Guid PlayerId { get; set; }

        public Player Player { get; set; }

        public Guid QuestionId { get; set; }

        public Question Question { get; set; }

        public Guid AnswerId { get; set; }

        public Answer Answer { get; set; }
    }
}