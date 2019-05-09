using System;
using System.Collections.Generic;

namespace IdentifiersConcept.Concept02
{
    /// <summary>
    /// Identifies something
    /// </summary>
    /// <remarks>
    /// This implementation allows the underlying identifying type to be specified
    /// </remarks>
    /// <typeparam name="TId">The underlying type</typeparam>
    public abstract class Identifier<TId> : IIdentifier, IEquatable<Identifier<TId>>
        where TId: IEquatable<TId>, IComparable<TId>
    {
        private readonly TId _id;

        protected virtual TId UndefinedId { get; } = default(TId);
        private bool? _isDefined;

        protected Identifier()
        {
            _isDefined = false;
        }

        protected Identifier(TId id)
        {
            _id = id;
        }

        public bool IsDefined
        {
            get
            {
                if (this._isDefined.HasValue)
                {
                    return this._isDefined.Value;
                }

                this._isDefined = !this._id.Equals(UndefinedId);

                return this._isDefined.Value;
            }
        }

        #region Equality

        public bool Equals(Identifier<TId> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _id.Equals(other._id) && this.GetType() == other.GetType();
        }

        public bool Equals(IIdentifier other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other is Identifier<TId> id)
            {
                return this.Equals(id);
            }

            return false;
        }

        public int CompareTo(IIdentifier other)
        {
            if (ReferenceEquals(null, other)) return 1;
            if (other is Identifier<TId> id)
            {
                if (this.GetType() != other.GetType())
                {
                    throw new ArgumentException($"Cannot compare to an instance of {other.GetType().Name}");
                }
                return this._id.CompareTo(id._id);
            }
            throw new ArgumentException($"Cannot compare to an instance of {other.GetType().Name}");
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Identifier<TId>) obj);
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public static bool operator ==(Identifier<TId> left, Identifier<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Identifier<TId> left, Identifier<TId> right)
        {
            return !Equals(left, right);
        }

        #endregion

        public override string ToString()
        {
            return IsDefined ? _id.ToString() : "undefined";
        }
    }
}
