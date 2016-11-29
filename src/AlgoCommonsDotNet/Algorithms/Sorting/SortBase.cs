using System;

namespace AlgoCommonsDotNet.Algorithms.Sorting
{
    /// <summary>
    /// Common methods for the sorting algorithms
    /// </summary>
    /// <typeparam name="T">Any type that implements IComparable</typeparam>
    public abstract class SortBase<T> where T : IComparable<T>
    {
        public delegate int ComparerDelegate(T item1, T item2);
        protected ComparerDelegate Comparer { get; set; }

        /// <summary>
        /// Sorts the given array based on the default comparer 
        /// (Ascending - Descending) or the given custom comparer which can be
        /// configured with the SetComparer method
        /// </summary>
        /// <param name="array">Array</param>
        public abstract void Sort(T[] array);

        /// <summary>
        /// Sorts the given array Ascending or Descending
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="order">Order</param>
        public void Sort(T[] array, SortingOrder order)
        {
            switch (order)
            {
                case SortingOrder.Ascending:
                    Comparer = AscendingComparer;
                    break;
                case SortingOrder.Descending:
                    Comparer = DescendingComparer;
                    break;
            }

            Sort(array);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SortBase()
        {
            //Sets the default comparer to ascending
            Comparer = AscendingComparer;
        }

        /// <summary>
        /// Set the comparer that we'll use to do comparisons
        /// </summary>
        /// <param name="comparer">Class that implements IComparable<T></param>
        public void SetComparer(ComparerDelegate comparer)
        {
            Comparer = comparer;
        }
        
        /// <summary>
        /// Shorthand method for CompareTo
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="i">Left index</param>
        /// <param name="j">Right index</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// <returns>-1 (Left < Right) 0 (Equals) or 1 (Left > Right</Right>)</returns>
        protected int Compare(T[] array, int i, int j)
        {
            return Comparer(array[i], array[j]);
        }

        /// <summary>
        /// Swap 2 items
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="i">Left index</param>
        /// <param name="j">Right index</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        protected void Swap(T[] array, int i, int j)
        {
            T aux = array[i];

            array[i] = array[j];
            array[j] = aux;
        }

        /// <summary>
        /// Ascending comparer
        /// </summary>
        /// <param name="item1">Item 1</param>
        /// <param name="item2">Item 2</param>
        /// <returns>-1 (Left < Right) 0 (Equals) or 1 (Left > Right</Right>)</returns>
        protected int AscendingComparer(T item1, T item2)
        {
            return item1.CompareTo(item2);
        }

        /// <summary>
        /// Descending comparer
        /// </summary>
        /// <param name="item1">Item 1</param>
        /// <param name="item2">Item 2</param>
        /// <returns>-1 (Right < Left) 0 (Equals) or 1 (Right > Left</Right>)</returns>
        protected int DescendingComparer(T item1, T item2)
        {
            return item2.CompareTo(item1);
        }
    }

    public enum SortingOrder
    {
        Ascending,
        Descending
    }
}
