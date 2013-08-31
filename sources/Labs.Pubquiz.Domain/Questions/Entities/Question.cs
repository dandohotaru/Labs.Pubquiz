using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Questions.Entities
{
    public class Question : Entity
    {
        public string Text { get; set; }

        public IList<Answer> Answers { get; set; }

        public IList<Tag> Tags { get; set; }
    }
}