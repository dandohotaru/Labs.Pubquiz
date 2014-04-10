using System;

namespace Labs.Pubquiz.Domain.Common.Entities
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
            return Equals((TEntity) other);
        }

        public static bool operator ==(Entity<TEntity> entity1, Entity<TEntity> entity2)
        {
            return ReferenceEquals(entity1, null)
                       ? ReferenceEquals(entity2, null)
                       : entity1.Equals(entity2);
        }

        public static bool operator !=(Entity<TEntity> entity1, Entity<TEntity> entity2)
        {
            return ReferenceEquals(entity1, null)
                       ? !ReferenceEquals(entity2, null)
                       : !entity1.Equals(entity2);
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