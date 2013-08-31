using System;
using Labs.Pubquiz.Domain.Common.Exceptions;

namespace Labs.Pubquiz.Domain.Common.Entities
{
    public class Entity<TEntity> : Entity
        where TEntity : class, IEntity
    {
        public TEntity WithId(Guid id)
        {
            if (id == default(Guid))
                throw new BusinessException("The {0} id is required.", typeof (TEntity).Name);
            Id = id;
            return this as TEntity;
        }
    }

    public class Entity : IEntity
    {
        public Guid Id { get; protected set; }
    }
}