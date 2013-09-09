using System;

namespace Labs.Pubquiz.Domain.Common
{
    public class Entity<TEntity> : Entity
        where TEntity : class, IEntity
    {
        public bool Equals(TEntity other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (other.GetType() != GetType())
                return false;
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public class Entity : IEntity
    {
        public Guid Id { get; set; }
    }
}