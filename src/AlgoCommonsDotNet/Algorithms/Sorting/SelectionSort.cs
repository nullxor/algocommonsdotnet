using System;

namespace AlgoCommonsDotNet.Algorithms.Sorting
{
    /// <summary>
    /// In computer science, selection sort is a sorting algorithm, 
    /// specifically an in-place comparison sort. It has O(n2) time
    /// complexity, making it inefficient on large lists, and generally
    /// performs worse than the similar insertion sort. 
    /// Selection sort is noted for its simplicity, and it has performance
    /// advantages over more complicated algorithms in certain situations,
    /// particularly where auxiliary memory is limited.
    /// 
    /// The algorithm divides the input list into two parts: the sublist of
    /// items already sorted, which is built up from left to right at the
    /// front(left) of the list, and the sublist of items remaining to be
    /// sorted that occupy the rest of the list.Initially, the sorted sublist
    /// is empty and the unsorted sublist is the entire input list. 
    /// The algorithm proceeds by finding the smallest (or largest, depending
    /// on sorting order) element in the unsorted sublist, exchanging(swapping)
    /// it with the leftmost unsorted element(putting it in sorted order), and
    /// moving the sublist boundaries one element to the right. 
    /// 
    /// From Wikipedia.
    /// </summary>
    public class SelectionSort<T> : SortBase<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorts the array using the Bubble Sort algorithm, O(n^2)
        /// </summary>
        /// <param name="array">Array to sort</param>
        public override void Sort(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                //Put the max or min item in the ordered portion of the array
                Swap(array, i, MinMax(array, i));
            }
        }

        /// <summary>
        /// Find the min or max index depending on the sorting order
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="from">Starting index</param>
        /// <returns>Max or Min index</returns>
        protected int MinMax(T[] array, int from)
        {
            int minMax = from;

            for (int i = from + 1; i < array.Length; i++)
            {
                if (Compare(array, from, i) > 0)
                {
                    minMax = i;
                }
            }

            return minMax;
        }
    }
}
