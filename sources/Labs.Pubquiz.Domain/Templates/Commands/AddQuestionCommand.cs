using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common.Commands;

namespace Labs.Pubquiz.Domain.Templates.Commands
{
    public class AddQuestionCommand : Command<AddQuestionCommand>
    {
        public string Text { get; set; }

        public TimeSpan Burndown { get; set; }

        public List<string> Tags { get; set; }
    }
}