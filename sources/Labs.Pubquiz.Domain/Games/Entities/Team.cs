using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Games.Entities
{
    public class Team : Entity
    {
        public string Name { get; set; }

        public Guid GameId { get; set; }

        public IList<Player> Players { get; set; }
    }
}