using System;

namespace Labs.Pubquiz.Domain.Common
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}