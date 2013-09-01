using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Questions.Entities
{
    /// <summary>
    ///   A label attached to a question for the purpose of identification or to give other information.
    /// </summary>
    public class Tag : Entity<Tag>
    {
        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public Tag Parent { get; set; }

        public IList<Tag> Children { get; set; }

        public IList<Question> Questions { get; set; }
    }
}