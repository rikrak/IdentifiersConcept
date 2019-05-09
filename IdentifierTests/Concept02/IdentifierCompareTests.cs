using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdentifierTests.Concept02
{
    [TestClass]
    public class IdentifierCompareTests
    {
        [TestMethod]
        public void ValuesAreSameInstance()
        {
            // arrange
            var first = new AddressId(32);

            // act
            var actual = first.CompareTo(first);

            // assert
            actual.Should().Be(0);
        }

        [TestMethod]
        public void ValuesAreSameValue()
        {
            // arrange
            var first = new AddressId(32);
            var second = new AddressId(32);

            // act
            var actual1 = first.CompareTo(second);
            var actual2 = second.CompareTo(first);

            // assert
            actual1.Should().Be(0);
            actual2.Should().Be(0);
        }

        [TestMethod]
        public void ValuesAreNotEqual()
        {
            // arrange
            var first = new AddressId(2);
            var second = new AddressId(3);

            // act
            var actual1 = first.CompareTo(second);
            var actual2 = second.CompareTo(first);

            // assert
            actual1.Should().BeLessThan(0);
            actual2.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void ValuesAreSameInstance_ListSort()
        {
            // arrange
            var first = new AddressId(32);
            var list = new List<AddressId> {first, first, first};

            // act
            list.Sort();

            // assert
            list.Should().ContainInOrder(first, first, first);
        }

        [TestMethod]
        public void ValuesShouldBeSortable()
        {
            // arrange
            var first = new AddressId(1);
            var second = new AddressId(2);
            var third = new AddressId(3);

            var list = new List<AddressId> {third, first, second};

            // act
            list.Sort();

            // assert
            list.Should().ContainInOrder(first, second, third);
        }
    }
}