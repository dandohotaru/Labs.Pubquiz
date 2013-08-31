using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Games.Entities
{
    /// <summary>
    ///   A person taking part in a quiz game.
    /// </summary>
    public class Player : Entity<Player>
    {
        public Guid UserId { get; set; }

        public string Alias { get; set; }

        public IList<Pick> Picks { get; set; }
    }
}