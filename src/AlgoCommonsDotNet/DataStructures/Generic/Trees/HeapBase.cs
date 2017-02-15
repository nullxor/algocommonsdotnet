using System;
using System.Collections.Generic;

namespace AlgoCommonsDotNet.DataStructures.Generic.Trees
{
   /*
    * In computer science, a heap is a specialized tree-based data structure
    * that satisfies the heap property: If A is a parent node of B then
    * the key (the value) of node A is ordered with respect to the key of node B
    * with the same ordering applying across the heap. A heap can be classified
    * further as either a "max heap" or a "min heap".
    *
    * From Wikipedia.
    */
    /// <summary>
    /// Base class for the Heap Data Structure
    /// </summary>
    public abstract class HeapBase<T> where T : IComparable
    {
        //Dynamic array, representation of the Heap
        protected List<T> _heap;

        public int Count { get { return _heap.Count; } }

        //Base constructor, general initialization
        protected HeapBase(T[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("The array should have elements");
            }

            _heap = new List<T>(array);

            //Heapify, it's _heap.Count / 2 because starting from (_heap.Count / 2) + 1
            //the nodes aren't root This operation is O(n)
            for (int i = (_heap.Count / 2); i >= 0; i--)
            {
                CheckDown(i);
            }
        }

        /// <summary>
        /// Array representation of the heap, just for testing purposes
        /// </summary>
        public T[] ToArray()
        {
            return _heap.ToArray();
        }

        //This should check if the left element greater than or lower than the right element
        protected abstract bool GreaterOrLower(int index1, int index2);

        /// <summary>
        /// Add a new element to the next spot available, rearranges the Heap
        /// and check the heap upwards
        /// </summary>
        /// <param name="element">Element</param>
        public void Add(T element)
        {
            _heap.Add(element);
            CheckUp(_heap.Count - 1);
        }

        /// <summary>
        /// Removes the top element
        /// </summary>
        /// <returns>Top element of the heap</returns>
        public T RemoveTop()
        {
            if (_heap.Count > 0)
            {
                T ret = _heap[0];

                Swap(0, _heap.Count - 1);
                _heap.RemoveAt(_heap.Count - 1);
                CheckDown(0);

                return ret;
            }

            return default(T);
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

        /// <summary>
        /// Calculate the root index, in a Heap represented by a zero index array,
        /// we can get it with the formula ((childIndex - 1) / 2)
        /// </summary>
        /// <param name="childIndex">Index of the child</param>
        /// <returns>Left index</returns>
        protected int RootIndex(int childIndex)
        {
            if (childIndex > 0)
            {
                return ((childIndex - 1) / 2);
            }

            return 0;
        }

        /// <summary>
        /// Check upwards
        /// </summary>
        /// <param name="fromIndex">From index</param>
        protected void CheckUp(int fromIndex)
        {
            int r = RootIndex(fromIndex);

            if (_heap[fromIndex].CompareTo(_heap[r]) > 0)
            {
                Swap(fromIndex, r);
                CheckUp(r);
            }
        }

        /// <summary>
        /// Check downwards
        /// </summary>
        /// <param name="rootIndex">Root index</param>
        protected void CheckDown(int rootIndex)
        {
            if (_heap.Count > 0)
            {
                int l = LeftIndex(rootIndex), r = RightIndex(rootIndex);
                int maxIndex = rootIndex;

                if (GreaterOrLower(l, maxIndex))
                {
                    maxIndex = l;
                }

                if (GreaterOrLower(r, maxIndex))
                {
                    maxIndex = r;
                }

                if (maxIndex != rootIndex)
                {
                    Swap(maxIndex, rootIndex);
                    CheckDown(maxIndex);
                }
            }
        }

        /// <summary>
        /// Swap two members of the inner heap
        /// </summary>
        /// <param name="i">left index</param>
        /// <param name="j">right index</param>
        protected void Swap(int i, int j)
        {
            T aux = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = aux;
        }
    }
}
