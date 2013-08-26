using System;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Games.Entities
{
    public class Player : Entity
    {
        public Guid UserId { get; set; }

        public string Alias { get; set; }

        public Guid TeamId { get; set; }

        public Team Team { get; set; }
    }
}