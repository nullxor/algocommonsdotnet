using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoCommonsDotNet.Algorithms.Sorting;

namespace AlgoCommonsTest.Algorithms.Sorting
{
    [TestClass]
    public class InsertionSortTests
    {
        int[] _arrayDesc;
        int[] _arrayAsc;
        SortBase<int> _sort;

        [TestInitialize]
        public void SetUp()
        {
            _arrayDesc = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            _arrayAsc = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            _sort = new InsertionSort<int>();
        }

        [TestMethod]
        public void ShouldOrderAscending()
        {
            _sort.Sort(_arrayDesc, SortingOrder.Ascending);
            Assert.IsTrue(SortUtils<int>.IsSortedAsc(_arrayDesc));
            Assert.IsTrue(SortUtils<int>.ArraysAreEquals(_arrayAsc, _arrayDesc));
        }

        [TestMethod]
        public void ShouldOrderDescending()
        {
            _sort.Sort(_arrayAsc, SortingOrder.Descending);
            Assert.IsTrue(SortUtils<int>.IsSortedDesc(_arrayAsc));
            Assert.IsTrue(SortUtils<int>.ArraysAreEquals(_arrayAsc, _arrayDesc));
        }
    }
}
