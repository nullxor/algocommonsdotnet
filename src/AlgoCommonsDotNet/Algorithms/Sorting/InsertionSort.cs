using System;

namespace AlgoCommonsDotNet.Algorithms.Sorting
{
    /// <summary>
    // Insertion sort is a simple sorting algorithm that builds the final sorted 
    // array(or list) one item at a time.It is much less efficient on large lists
    // than more advanced algorithms such as quicksort, heapsort, or merge sort.
    // From Wikipedia.
    /// </summary>
    public class InsertionSort<T> : SortBase<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorts the array using the Insertion Sort algorithm,
        /// this algorithm is O(n^2)
        /// </summary>
        /// <param name="array">Array to sort</param>
        public override void Sort(T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;

                while ((j > 0) && (Compare(array, j, j - 1) < 0))
                {
                    Swap(array, j, j - 1);
                    j--;
                }
            }
        }
    }
}
