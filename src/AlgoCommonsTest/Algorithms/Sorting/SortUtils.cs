using System;
using System.Linq;

namespace AlgoCommonsTest.Algorithms.Sorting
{
    public class SortUtils<T> where T : IComparable<T>
    {
        /// <summary>
        /// Checks if the array is sorted in ascending nondecreasing order
        /// it doesn't check for empty or one elements arrays
        /// </summary>
        /// <param name="array">Array</param>
        /// <returns>true if it's sorted else false</returns>
        public static bool IsSortedAsc(T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(array[i - 1]) < 0)
                {
                    return false;
                } 
            }

            return true;
        }

        /// <summary>
        /// Checks if the array is sorted in descending nonincreasing order
        /// it doesn't check for empty or one elements arrays
        /// </summary>
        /// <param name="array">Array</param>
        /// <returns>true if it's sorted else false</returns>
        public static bool IsSortedDesc(T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(array[i - 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the arrays are equals member by member
        /// </summary>
        /// <param name="array1">Array 1</param>
        /// <param name="array2">Array 2</param>
        /// <returns></returns>
        public static bool ArraysAreEquals(T[] array1, T[] array2)
        {
            return array1.SequenceEqual(array2);
        }
    }
}
