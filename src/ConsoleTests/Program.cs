﻿using AlgoCommonsDotNet.Algorithms.Sorting;
using AlgoCommonsDotNet.DataStructures.Generic.Lists;
using AlgoCommonsTest.Algorithms.Sorting;
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
            int[] array = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            
            SortBase<int> sort = new SelectionSort<int>();

            sort.Sort(array, SortingOrder.Ascending);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
    }
}
