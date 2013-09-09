using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Questions.Entities
{
    /// <summary>
    ///   A matter forming the basis of a problem requiring resolution for any quiz.
    /// </summary>
    public class Question : Entity<Question>
    {
        public string Text { get; set; }

        public IList<Answer> Answers { get; set; }

        public IList<Tag> Tags { get; set; }
    }
}