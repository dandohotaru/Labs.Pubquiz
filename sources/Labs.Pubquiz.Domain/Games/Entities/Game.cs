using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Games.Entities
{
    public class Game : Entity
    {
        public string Name { get; set; }

        public string Venue { get; set; }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }

        public IList<Team> Teams { get; set; }

        public IList<Round> Rounds { get; set; }
    }
}