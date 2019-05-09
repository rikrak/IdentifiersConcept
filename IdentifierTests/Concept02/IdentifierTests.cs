using FluentAssertions;
using IdentifiersConcept.Concept02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdentifierTests.Concept02
{
    [TestClass]
    public class IdentifierTests
    {
        [TestMethod]
        public void SameInstance()
        {
            // arrange
            var lhs = new PersonId(23);

            // act & assert
            RunEqualityTest(lhs, lhs, true);
        }

        [TestMethod]
        public void EquivalentValues()
        {
            // arrange
            var lhs = new PersonId(23);
            var rhs = new PersonId(23);

            // act & assert
            RunEqualityTest(lhs, rhs, true);
        }

        [TestMethod]
        public void DifferentValues()
        {
            // arrange
            var lhs = new PersonId(24);
            var rhs = new PersonId(23);

            // act & assert
            RunEqualityTest(lhs, rhs, false);
        }

        [TestMethod]
        public void CompareToNull()
        {
            // arrange
            var lhs = new PersonId(23);
            const PersonId rhs = null;

            // act & assert
            RunEqualityTest(lhs, rhs, false);
        }

        [TestMethod]
        public void CompareToDifferentIdentifierWithSameValue()
        {
            // arrange
            var lhs = new PersonId(23);
            var rhs = new AddressId(23);

            // act & assert
            (lhs == rhs).Should().BeFalse();
            (lhs != rhs).Should().BeTrue();
        }

        private void RunEqualityTest(Identifier<int> lhs, Identifier<int> rhs, bool areExpectedToBeEqual, string because = null)
        {
            // arrange

            // act
            var actualFromOperator = lhs == rhs;
            var actualFromOperatorReversed = rhs == lhs;
            var actualFromInverseOperator = lhs != rhs;
            var actualFromInverseOperatorReversed = rhs != lhs;
            var actualFromMethod = lhs != null ? lhs.Equals(rhs) : areExpectedToBeEqual;
            var actualFromMethodReversed = rhs != null ? rhs.Equals(lhs) : areExpectedToBeEqual;
            var lhsHash = lhs?.GetHashCode();
            var rhsHash = rhs?.GetHashCode();

            // assert
            actualFromInverseOperator.Should().Be(!areExpectedToBeEqual, "The instances are {0}equal {1}", areExpectedToBeEqual ? "" : "not ", because);
            actualFromInverseOperatorReversed.Should().Be(!areExpectedToBeEqual, "The instances are {0}equal {1}", areExpectedToBeEqual ? "" : "not ", because);
            actualFromOperator.Should().Be(areExpectedToBeEqual, "The instances are {0}equal {1}", areExpectedToBeEqual ? "" : "not ", because);
            actualFromOperatorReversed.Should().Be(areExpectedToBeEqual, "The instances are {0}equal {1}", areExpectedToBeEqual ? "" : "not ", because);
            actualFromMethod.Should().Be(areExpectedToBeEqual, "The instances are {0}equal {1}", areExpectedToBeEqual ? "" : "not ", because);
            actualFromMethodReversed.Should().Be(areExpectedToBeEqual, "The instances are {0}equal {1}", areExpectedToBeEqual ? "" : "not ", because);

            if (areExpectedToBeEqual)
            {
                if (lhs != null) { lhs.Should().Be(rhs); }
                if (rhs != null) { rhs.Should().Be(lhs); }
                if (lhsHash.HasValue)
                {
                    lhsHash.Should().Be(rhsHash);
                }
            }
            else
            {
                if (lhs != null) { lhs.Should().NotBe(rhs); }
                if (rhs != null) { rhs.Should().NotBe(lhs); }
                if (lhsHash.HasValue)
                {
                    lhsHash.Should().NotBe(rhsHash);
                }
            }
        }
    }
}
