using NUnit.Framework;
using System.Linq;
using AlgoCommonsDotNet.DataStructures.Generic.Trees.Heap;

namespace AlgoCommonsTest.DataStructures.Generic.Trees
{
    [TestFixture]
    public class MinHeapTests
    {
        HeapBase<int> _heap;
        int[] _array;

        [SetUp]
        public void SetUp()
        {
            _array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _heap = new MinHeap<int>(_array);
        }

        [Test]
        public void ShouldReturnTheMinElementAfterRemoveTop()
        {
            var array = _heap.ToArray();
            var min = _heap.RemoveTop();
            Assert.AreEqual(array.Min(), min);
        }
    }
}
