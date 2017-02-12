using NUnit.Framework;
using AlgoCommonsDotNet.Algorithms.Sorting;

namespace AlgoCommonsTest.Algorithms.Sorting
{
    /// <summary>
    /// Gemeral tests for the abstract class
    /// </summary>
    [TestFixture]
    public class SortBaseTests
    {
        SortBase<int> _sort;

        [SetUp]
        public void SetUp()
        {
            _sort = new BubbleSort<int>();
        }

        [Test]
        public void ShouldBeOkWithEmptyArrays()
        {
            int[] empty = {};

            //If this doesn't throws any exception then the code is ok
            _sort.Sort(empty);
        }

        [Test]
        public void ShouldBeOkWithOneElementArrays()
        {
            int[] empty = { 1 };

            _sort.Sort(empty);
            Assert.AreEqual(1, empty[0]);
        }
    }
}
