using System;
using System.Collections.Generic;

namespace AlgoCommonsDotNet.Algorithms.Sorting
{
    /*
     * Quicksort (sometimes called partition-exchange sort) is an efficient
     * sorting algorithm, serving as a systematic method for placing the
     * elements of an array in order. Developed by Tony Hoare in 1959, with
     * his work published in 1961, it is still a commonly used algorithm for sorting.
     * When implemented well, it can be about two or three times faster than its main
     * competitors, merge sort and heapsort.
     * Quicksort is a comparison sort, meaning that it can sort items of any type for
     * which a "less-than" relation(formally, a total order) is defined. In efficient
     * implementations it is not a stable sort, meaning that the relative order of equal
     * sort items is not preserved.Quicksort can operate in-place on an array,
     * requiring small additional amounts of memory to perform the sorting.
     *
     * From Wikipedia
     */

    /// <summary>
    /// Quicksort
    /// </summary>
    public class QuickSort<T> : SortBase<T> where T : IComparable<T>
    {
        public override void Sort(T[] array)
        {
            QuickSortAux(array, 0, array.Length - 1);
        }

        protected void QuickSortAux(T[] array, int left, int right)
        {
            int length = right - left;

            if (length > 0)
            {
                int partition = Partition(array, left, right);

                QuickSortAux(array, left, partition - 1);
                QuickSortAux(array, partition + 1, right);
            }
        }

        /// <summary>
        /// Computes the partition
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="left">From</param>
        /// <param name="right">To</param>
        /// <returns>Index of the partition</returns>
        protected int Partition(T[] array, int left, int right)
        {
            int l = left, r = right;
            T pivot = array[GetPivotIndex(array, left, right)];

            while (l < r)
            {
                while (Comparer(array[l], pivot) < 0) { l++; }
                while (Comparer(array[r], pivot) > 0) { r--; }

                if (l < r)
                {
                    Swap(array, l, r);
                }
            }

            return l;
        }

        /// <summary>
        /// Computes the pivot index, in this case the middle index
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="left">From</param>
        /// <param name="right">To</param>
        /// <returns>Index of the pivot</returns>
        protected int GetPivotIndex(IList<T> array, int left, int right)
        {
            return left + ((right - left) / 2);
        }
    }
}
