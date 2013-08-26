using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Games
{
    public class Question : Entity
    {
        public Guid QuestionId { get; set; }

        public Guid RoundId { get; set; }

        public Round Round { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}