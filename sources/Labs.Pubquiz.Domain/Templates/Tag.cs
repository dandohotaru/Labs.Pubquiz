using System.Collections.Generic;
using Labs.Pubquiz.Domain.Common;

namespace Labs.Pubquiz.Domain.Templates
{
    public class Tag : Entity
    {
        public string Name { get; set; }

        public Tag Parent { get; set; }

        public IList<Tag> Children { get; set; }
    }
}