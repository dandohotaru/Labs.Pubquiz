using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Games
{
    public class Round : Entity
    {
        public string Name { get; set; }

        public IList<Question> Questions { get; set; }
    }
}