﻿using System;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Games
{
    public class Answer : Entity
    {
        public Guid AnswerId { get; set; }

        public Guid PlayerId { get; set; }

        public Player Player { get; set; }

        public Guid QuestionId { get; set; }

        public Question Question { get; set; }
    }
}