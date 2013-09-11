using System;
using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Questions.Entities
{
    /// <summary>
    ///   A label attached to a concept for the purpose of identification or to give other information.
    /// </summary>
    public class Tag : Entity<Tag>
    {
        public Tag(Guid id, string name)
        {
            if (id == default(Guid))
                throw new ArgumentException("id");
            if (name == null)
                throw new ArgumentNullException("name");

            Id = id;
            Name = name;
        }

        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public Tag Parent { get; set; }

        public IList<Tag> Children { get; set; }
    }
}