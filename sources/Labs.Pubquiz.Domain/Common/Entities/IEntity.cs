using System;

namespace Labs.Pubquiz.Domain.Common.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}