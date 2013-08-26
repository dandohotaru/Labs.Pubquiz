using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Games.Entities
{
    public class Round : Entity
    {
        public string Name { get; set; }

        public IList<Question> Questions { get; set; }
    }
}