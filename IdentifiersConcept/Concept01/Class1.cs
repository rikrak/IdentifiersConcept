using System;

namespace IdentifiersConcept.Concept01
{
    public interface IIdentifier : IEquatable<IIdentifier>, IComparable<IIdentifier>
    {

    }
    public abstract class Identifier : IIdentifier, IEquatable<Identifier>
    {
        private const int UndefinedId = Int32.MinValue;
        private readonly int _id;
        

        protected Identifier()
        {
            _id = UndefinedId;
        }
        protected Identifier(int id)
        {
            _id = id;
        }

        public bool IsDefined => _id != UndefinedId;

        #region Equality

        public bool Equals(Identifier other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _id == other._id;
        }

        public bool Equals(IIdentifier other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other is Identifier id)
            {
                return this.Equals(id);
            }

            return false;
        }

        public int CompareTo(IIdentifier other)
        {
            if (ReferenceEquals(null, other)) return -1;
            if (other is Identifier id)
            {
                return this._id.CompareTo(id._id);
            }

            // how to compare ids of different types?
            // I suppose it's arbitrary?
            // if so, a quick compare would be good
            return string.CompareOrdinal(this.GetType().Name, other.GetType().Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Identifier) obj);
        }

        public override int GetHashCode()
        {
            return _id;
        }

        public static bool operator ==(Identifier left, Identifier right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Identifier left, Identifier right)
        {
            return !Equals(left, right);
        }

        #endregion

        public override string ToString()
        {
            return IsDefined ? _id.ToString("d") : "undefined";
        }
    }
}
