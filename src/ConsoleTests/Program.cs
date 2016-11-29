using AlgoCommonsDotNet.Algorithms.Sorting;
using AlgoCommonsDotNet.DataStructures.Generic.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests
{
    /// <summary>
    /// General tests
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            SortBase<int> sort = new BubbleSort<int>();

            sort.Sort(array, SortingOrder.Descending);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
    }
}
