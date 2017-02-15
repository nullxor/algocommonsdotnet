using System;
using System.Collections.Generic;

namespace AlgoCommonsDotNet.Algorithms.Sorting
{
   /*
    * Top-Down Merge Sort implementation
    *
    * In computer science, merge sort (also commonly spelled mergesort)
    * is an efficient, general-purpose, comparison-based sorting algorithm.
    * Most implementations produce a stable sort, which means that the
    * implementation preserves the input order of equal elements in the sorted
    * output. Mergesort is a divide and conquer algorithm that was invented by
    * John von Neumann in 1945.
    *
    * From Wikipedia.
    */
    /// <summary>
    /// Top down Merge sort
    /// </summary>
    public class MergeSort<T> : SortBase<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorts the array using the Merge sort algorithm, it's O(n logn)
        /// </summary>
        /// <param name="array"></param>
        public override void Sort(T[] array)
        {
            IList<T> buffer = new T[array.Length];
            MergeSortAux(array, buffer, 0, array.Length);
        }

        /// <summary>
        /// Top down Merge sort
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="buffer">Buffer</param>
        /// <param name="from">From index</param>
        /// <param name="to">To index</param>
        protected void MergeSortAux(IList<T> array, IList<T> buffer, int from, int to)
        {
            int length = (to - from);

            if (length > 1)
            {
                int middle = from + (length / 2);

                MergeSortAux(array, buffer, from, middle);
                MergeSortAux(array, buffer, middle, to);

                Merge(array, buffer, from, middle, to);
            }
        }

        /// <summary>
        /// Merge two arrays into one ordered array, we require a temp buffer
        /// as a parameter, although we could have created that buffer inside
        /// the Merge method, this would generate too much garbage for the GC
        /// because Merge is called several times.
        /// </summary>
        /// <param name="result">Where to merge</param>
        /// <param name="buffer">Tmp array</param>
        /// <param name="leftArray">Left array</param>
        /// <param name="rightArray">Right array</param>
        /// <returns>Merged ordered array</returns>
        protected void Merge(IList<T> result, IList<T> buffer, int from, int middle, int to)
        {
            int leftIndex = from, rightIndex = middle, resultIndex = from;

            while ((leftIndex < middle) && (rightIndex < to))
            {
                if (Comparer(result[leftIndex], result[rightIndex]) <= 0)
                {
                    buffer[resultIndex++] = result[leftIndex++];
                }
                else
                {
                    buffer[resultIndex++] = result[rightIndex++];
                }
            }

            //Copy the rest of items
            for (int i = leftIndex; i < middle; i++)
            {
                buffer[resultIndex++] = result[i];
            }

            for (int i = rightIndex; i < to; i++)
            {
                buffer[resultIndex++] = result[i];
            }

            //Copy to the original array
            for (int i = from; i < to; i++)
            {
                result[i] = buffer[i];
            }
        }
    }
}
