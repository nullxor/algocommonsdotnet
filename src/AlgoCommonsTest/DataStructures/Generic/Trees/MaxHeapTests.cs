using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoCommonsDotNet.DataStructures.Generic.Trees;

namespace AlgoCommonsTests.DataStructures.Generic.Trees
{
    /// <summary>
    /// MaxHeap tests
    /// </summary>
    [TestClass]
    public class MaxHeapTests
    {
        HeapBase<int> _heap;
        int[] _array;

        [TestInitialize]
        public void SetUp()
        {
            _array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _heap = new MaxHeap<int>(_array);
        }

        [TestMethod]
        public void EmptyArrayShouldReturnArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var emptyHeap = new MaxHeap<int>(new int[] { });
            });
        }

        [TestMethod]
        public void ShouldReturnTheCorrectHeapSize()
        {
            Assert.AreEqual(9, _heap.Count);
        }

        [TestMethod]
        public void ShouldReturnTheCorrectHeapSizeAfterRemoveTop()
        {
            _heap.RemoveTop();
            Assert.AreEqual(8, _heap.Count);
        }

        [TestMethod]
        public void ShouldReturnTheMaxElementAfterRemoveTop()
        {
            var array = _heap.ToArray();
            var max = _heap.RemoveTop();
            Assert.AreEqual(array.Max(), max);
        }
    }
}
