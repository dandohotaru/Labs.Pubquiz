using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Templates
{
    public class Answer : Entity
    {
        public string Text { get; set; }

        public bool Correct { get; set; }

        public int Number { get; set; }
    }
}