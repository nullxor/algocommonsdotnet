using System;
using System.Linq;
using NUnit.Framework;
using AlgoCommonsDotNet.DataStructures.Generic.Lists;

namespace AlgoCommonsTest.DataStructures.Generic.Arrays
{
    [TestFixture]
    public class DynamicArrayTests
    {
        const int TestLength = 50;
        DynamicArray<int> _dynamicArray;
        
        [SetUp]
        public void SetUp()
        {
            //Array from 0 to 50 for easy indexing (index==value)
            int[] array = Enumerable.Range(0, TestLength).ToArray();
            _dynamicArray = new DynamicArray<int>(array);
        }

        [Test]
        public void ShouldReturnTheCorrectLength()
        {
            Assert.AreEqual(TestLength, _dynamicArray.Length);
        }

        [Test]
        public void ShouldReturnTheCorrectItem()
        {
            Assert.AreEqual(_dynamicArray[25], 25);
        }

        [Test]
        public void ShouldInsertCorrectly()
        {
            _dynamicArray.InsertAt(0, 100);
            Assert.AreEqual(_dynamicArray[0], 100);
        }

        [Test]
        public void ShouldRemoveCorrectly()
        {
            var item = _dynamicArray.RemoveAt(25);

            Assert.AreEqual(item, 25);
            Assert.AreEqual(TestLength - 1, _dynamicArray.Length);
        }

        [Test]
        public void ShouldReturnTheCorrectLengthAfterInsertion()
        {
            _dynamicArray.Add(51);
            _dynamicArray.InsertAt(0, -1);
            Assert.AreEqual(TestLength + 2, _dynamicArray.Length);
        }

        [Test]
        public void ShouldReturnTheCorrectLengthAfterDeletion()
        {
            _dynamicArray.RemoveAt(0);
            _dynamicArray.RemoveAt(0);
            Assert.AreEqual(TestLength - 2, _dynamicArray.Length);
        }

        [Test]
        public void ShouldThrowsExceptionIfIndexIsOutOfRange()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var item = _dynamicArray[TestLength * 3];
            });
        }

        [Test]
        public void ShouldThrowsExceptionIfDeletingFromEmptyArray()
        {
            DynamicArray<int> empty = new DynamicArray<int>();

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                empty.RemoveAt(5);
            });
        }
    }
}
