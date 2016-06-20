using System;
using System.Collections.Generic;

namespace DotPlatform.Domain.Entities
{
    /// <summary>
    /// 领域对象实体
    /// </summary>
    /// <typeparam name="TPrimaryKey">实体主键类型</typeparam>
    [Serializable]
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        #region IEntity<TPrimaryKey> Members

        public virtual TPrimaryKey Id { get; set; }

        public virtual bool IsTransient()
        {
            return EqualityComparer<TPrimaryKey>.Default.Equals(this.Id, default(TPrimaryKey));
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity<TPrimaryKey>))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var other = (Entity<TPrimaryKey>) obj;
            if (this.IsTransient() && other.IsTransient())
                return false;

            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right)
        {
            if (Equals(left, null))
                return Equals(right, null);

            return left.Equals(right);
        }

        public static bool operator !=(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right)
        {
            return !(left == right);
        }

        #endregion
    }

    /// <summary>
    /// 领域对象实体。实体主键类型 <see cref="Guid"/>
    /// </summary>
    [Serializable]
    public abstract class Entity : Entity<Guid>
    {
        
    }
}
