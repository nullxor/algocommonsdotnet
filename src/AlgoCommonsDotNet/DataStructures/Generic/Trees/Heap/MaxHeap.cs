using System;
using System.Collections.Generic;

namespace AlgoCommonsDotNet.DataStructures.Generic.Trees.Heap
{
    /// <summary>
    /// Implementation of a MaxHeap data structure
    /// </summary>
    /// <typeparam name="T">Data type, it must implements the IComparable interface</typeparam>
    public class MaxHeap<T> : HeapBase<T> where T : IComparable
    {
        public MaxHeap(IList<T> array) : base(array)
        {
        }

        /// <summary>
        /// In this case this checks if _heap[index1] > _heap[index2]
        /// because it's MaxHeap
        /// </summary>
        /// <param name="index1">Index 1</param>
        /// <param name="index2">Index 2</param>
        /// <returns></returns>
        protected override bool GreaterOrLower(int index1, int index2)
        {
            if (index2 >= _heap.Count)
            {
                return true;
            }

            if (index1 < _heap.Count)
            {
                return _heap[index1].CompareTo(_heap[index2]) > 0;
            }

            return false;
        }
    }
}
