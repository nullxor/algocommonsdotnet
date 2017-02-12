using NUnit.Framework;
using AlgoCommonsDotNet.Algorithms.Sorting;

namespace AlgoCommonsTest.Algorithms.Sorting
{
    [TestFixture]
    public class InsertionSortTests
    {
        int[] _arrayDesc;
        int[] _arrayAsc;
        SortBase<int> _sort;

        [SetUp]
        public void SetUp()
        {
            _arrayAsc  = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _arrayDesc = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

            _sort = new InsertionSort<int>();
        }

        [Test]
        public void ShouldOrderAscending()
        {
            _sort.Sort(_arrayDesc, SortingOrder.Ascending);
            Assert.IsTrue(SortUtils<int>.IsSortedAsc(_arrayDesc));
            Assert.IsTrue(SortUtils<int>.ArraysAreEquals(_arrayAsc, _arrayDesc));
        }

        [Test]
        public void ShouldOrderDescending()
        {
            _sort.Sort(_arrayAsc, SortingOrder.Descending);
            Assert.IsTrue(SortUtils<int>.IsSortedDesc(_arrayAsc));
            Assert.IsTrue(SortUtils<int>.ArraysAreEquals(_arrayAsc, _arrayDesc));
        }
    }
}
