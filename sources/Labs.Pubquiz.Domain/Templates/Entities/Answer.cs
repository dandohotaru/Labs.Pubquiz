using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Templates.Entities
{
    public class Answer : Entity
    {
        public string Text { get; set; }

        public bool Correct { get; set; }

        public int Number { get; set; }
    }
}