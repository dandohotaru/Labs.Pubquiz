using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Templates.Entities
{
    public class Tag : Entity
    {
        public string Name { get; set; }

        public Tag Parent { get; set; }

        public IList<Tag> Children { get; set; }
    }
}