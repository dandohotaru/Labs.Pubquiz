using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Security.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; }
    }
}