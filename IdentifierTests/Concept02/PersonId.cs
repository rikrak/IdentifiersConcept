using System;
using IdentifiersConcept.Concept02;

namespace IdentifierTests.Concept02
{
    public abstract class EntityId : Identifier<int>
    {
        protected EntityId(){}
        protected EntityId(int value):base(value){}
    }
    public class PersonId : EntityId
    {
        private PersonId() { }
        public PersonId(int value):base(value) { }
        
        public static PersonId Undefined { get; } =new PersonId();
    }
    public class AddressId : EntityId
    {
        private AddressId() {}
        public AddressId(int value):base(value) { }

        public static AddressId Undefined { get; } = new AddressId();
    }

    public class UserId : Identifier<Guid>
    {
        private UserId() { }
        public UserId(Guid value):base(value) { }

        public static UserId Undefined { get; } = new UserId();
    }
}
