using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoCommonsDotNet.DataStructures.Generic.Lists;

namespace AlgoCommonsTest.DataStructures.Generic.Arrays
{
    [TestClass]
    public class DynamicArrayTests
    {
        const int TestLength = 50;
        DynamicArray<int> _dynamicArray;
        
        [TestInitialize]
        public void SetUp()
        {
            //Array from 0 to 50 for easy indexing (index==value)
            int[] array = Enumerable.Range(0, TestLength).ToArray();
            _dynamicArray = new DynamicArray<int>(array);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectLength()
        {
            Assert.AreEqual(TestLength, _dynamicArray.Length);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectItem()
        {
            Assert.AreEqual(_dynamicArray[25], 25);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectItemAfterDeletion()
        {
            var item = _dynamicArray.RemoveAt(25);

            Assert.AreEqual(item, 25);
            Assert.AreEqual(TestLength - 1, _dynamicArray.Length);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectLengthAfterInsertion()
        {
            _dynamicArray.Add(51);
            _dynamicArray.Add(52);
            Assert.AreEqual(TestLength + 2, _dynamicArray.Length);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectLengthAfterDeletion()
        {
            _dynamicArray.RemoveAt(0);
            _dynamicArray.RemoveAt(0);
            Assert.AreEqual(TestLength - 2, _dynamicArray.Length);
        }

        [TestMethod]
        public void ShouldThrowsExceptionIfIndexIsOutOfRange()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                var item = _dynamicArray[TestLength * 3];
            });
        }

        [TestMethod]
        public void ShouldThrowsExceptionIfDeletingFromEmptyArray()
        {
            DynamicArray<int> empty = new DynamicArray<int>();

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                empty.RemoveAt(5);
            });
        }
    }
}
