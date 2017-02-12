using System;
using System.Linq;
using NUnit.Framework;
using AlgoCommonsDotNet.DataStructures.Generic.Trees;

namespace AlgoCommonsTests.DataStructures.Generic.Trees
{
    /// <summary>
    /// MaxHeap tests
    /// </summary>
    [TestFixture]
    public class MaxHeapTests
    {
        HeapBase<int> _heap;
        int[] _array;

        [SetUp]
        public void SetUp()
        {
            _array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _heap = new MaxHeap<int>(_array);
        }

        [Test]
        public void EmptyArrayShouldReturnArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new MaxHeap<int>(new int[] { });
            });
        }

        [Test]
        public void ShouldReturnTheCorrectHeapSize()
        {
            Assert.AreEqual(9, _heap.Count);
        }

        [Test]
        public void ShouldReturnTheCorrectHeapSizeAfterRemoveTop()
        {
            _heap.RemoveTop();
            Assert.AreEqual(8, _heap.Count);
        }

        [Test]
        public void ShouldReturnTheMaxElementAfterRemoveTop()
        {
            var array = _heap.ToArray();
            var max = _heap.RemoveTop();
            Assert.AreEqual(array.Max(), max);
        }
    }
}
