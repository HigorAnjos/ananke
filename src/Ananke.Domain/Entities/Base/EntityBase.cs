using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananke.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public override bool Equals(object obj)
        {
            var other = obj as EntityBase;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (Id == Guid.Empty || other.Id == Guid.Empty)
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(EntityBase a, EntityBase b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntityBase a, EntityBase b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        public void SetId()
        {
            Id = Guid.NewGuid();
        }

        public void SetCreatedAt()
        {
            CreatedAt = DateTime.Now;
        }

        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.Now;
        }

        public void SetUpdatedAt(DateTime Newdate)
        {
            UpdatedAt = Newdate;
        }
    }
}
