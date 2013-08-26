using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Games
{
    public class Team : Entity
    {
        public string Name { get; set; }

        public Guid GameId { get; set; }

        public IList<Player> Players { get; set; }
    }
}