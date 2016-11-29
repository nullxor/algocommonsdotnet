using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoCommonsDotNet.Algorithms.Sorting;

namespace AlgoCommonsTest.Algorithms.Sorting
{
    /// <summary>
    /// Gemeral tests for the abstract class
    /// </summary>
    [TestClass]
    public class SortBaseTests
    {
        SortBase<int> _sort;

        [TestInitialize]
        public void SetUp()
        {
            _sort = new BubbleSort<int>();
        }

        [TestMethod]
        public void ShouldBeOkWithEmptyArrays()
        {
            int[] empty = {};

            //If this don't throws any exception then the code is ok
            _sort.Sort(empty);
        }

        [TestMethod]
        public void ShouldBeOkWithOneElementArrays()
        {
            int[] empty = { 1 };

            _sort.Sort(empty);
            Assert.AreEqual(1, empty[0]);
        }
    }
}
