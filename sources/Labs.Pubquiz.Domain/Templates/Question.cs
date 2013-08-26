﻿using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Templates
{
    public class Question : Entity
    {
        public string Text { get; set; }

        public TimeSpan Burndown { get; set; }

        public IList<Answer> Answers { get; set; }

        public IList<Tag> Tags { get; set; }
    }
}