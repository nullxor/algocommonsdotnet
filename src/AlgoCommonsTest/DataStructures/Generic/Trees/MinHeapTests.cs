using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoCommonsDotNet.DataStructures.Generic.Trees;
using System.Linq;

namespace AlgoCommonsTest.DataStructures.Generic.Trees
{
    [TestClass]
    public class MinHeapTests
    {
        HeapBase<int> _heap;
        int[] _array;

        [TestInitialize]
        public void SetUp()
        {
            _array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _heap = new MinHeap<int>(_array);
        }

        [TestMethod]
        public void ShouldReturnTheMinElementAfterRemoveTop()
        {
            var array = _heap.ToArray();
            var min = _heap.RemoveTop();
            Assert.AreEqual(array.Min(), min);
        }
    }
}
