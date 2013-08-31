using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Games.Entities
{
    /// <summary>
    ///   A division of a contest such as a quiz game.
    /// </summary>
    public class Round : Entity
    {
        public string Name { get; set; }

        public Guid GameId { get; set; }

        public Game Game { get; set; }

        public IList<Question> Questions { get; set; }

        public bool Active { get; set; }
    }
}