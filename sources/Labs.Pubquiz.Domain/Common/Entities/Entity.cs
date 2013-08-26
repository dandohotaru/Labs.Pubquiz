using System;

namespace Labs.Pubquiz.Domain.Common.Entities
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }
    }
}