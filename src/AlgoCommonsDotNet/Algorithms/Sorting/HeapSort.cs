using System;
using System.Collections.Generic;
using AlgoCommonsDotNet.Algorithms.Sorting;

namespace AlgoCommonsDotNet.Algorithms.Sorting
{
   /*
    * Is a comparison-based sorting algorithm. Heapsort can be thought of as
    * an improved selection sort: like that algorithm, it divides its input
    * into a sorted and an unsorted region, and it iteratively shrinks the
    * unsorted region by extracting the largest element and moving that to
    * the sorted region. The improvement consists of the use of a heap data
    * structure rather than a linear-time search to find the maximum.
    *
    * From Wikipedia.
    */
    /// <summary>
    /// Heapsort
    /// </summary>
    public class HeapSort<T> : SortBase<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorts the array using the Heap Sort algorithm O(n logn)
        /// </summary>
        /// <param name="array"></param>
        public override void Sort(T[] array)
        {
            BuildHeap(array);

            for (int length = array.Length - 1; length > 0; length--)
            {
                Swap(array, 0, length);
                Heapify(array, 0, length);
            }
        }

        /// <summary>
        /// Build the heap, it takes O(n)
        /// </summary>
        /// <param name="array">Array</param>
        protected void BuildHeap(T[] array)
        {
            for (int i = array.Length / 2; i >= 0; i--)
            {
                Heapify(array, i, array.Length);
            }
        }

        /// <summary>
        /// Check downwards
        /// </summary>
        /// <param name="rootIndex">Root index</param>
        protected void Heapify(T[] array, int rootIndex, int length)
        {
            int l = LeftIndex(rootIndex), r = RightIndex(rootIndex);
            int maxIndex = rootIndex;

            if (l < length && Compare(array, l, maxIndex) > 0)
            {
                maxIndex = l;
            }

            if (r < length && Compare(array, r, maxIndex) > 0)
            {
                maxIndex = r;
            }

            if (maxIndex != rootIndex)
            {
                Swap(array, maxIndex, rootIndex);
                Heapify(array, maxIndex, length);
            }
        }

        /// <summary>
        /// Calculate the left index, in a Heap represented by a zero index array,
        /// we can get it with the simple formula (rootIndex * 2) + 1
        /// </summary>
        /// <param name="rootIndex">Index of the root</param>
        /// <returns>Left index</returns>
        protected int LeftIndex(int rootIndex)
        {
            return (rootIndex * 2) + 1;
        }

        /// <summary>
        /// Calculate the right index, in a Heap represented by a zero index array,
        /// we can get it with the simple formula (rootIndex * 2) + 2
        /// </summary>
        /// <param name="childIndex">Index of the root</param>
        /// <returns>Left index</returns>
        protected int RightIndex(int rootIndex)
        {
            return (rootIndex * 2) + 2;
        }
    }
}
