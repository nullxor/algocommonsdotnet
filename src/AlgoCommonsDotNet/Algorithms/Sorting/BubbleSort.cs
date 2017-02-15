using System;

namespace AlgoCommonsDotNet.Algorithms.Sorting
{
    /// <summary>
    /// Bubblesort
    /// </summary>
    public class BubbleSort<T> : SortBase<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorts the array using the Bubble Sort algorithm, this algorithm
        /// is very simple and inefficient, it's O(n^2)
        /// </summary>
        /// <param name="array">Array to sort</param>
        public override void Sort(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (Compare(array, i, j) > 0)
                    {
                        Swap(array, i, j);
                    }
                }
            }
        }
    }
}
