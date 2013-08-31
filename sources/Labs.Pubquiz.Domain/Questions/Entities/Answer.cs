using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Questions.Entities
{
    public class Answer : Entity
    {
        public int Number { get; set; }

        public string Text { get; set; }

        public bool Correct { get; set; }
    }
}