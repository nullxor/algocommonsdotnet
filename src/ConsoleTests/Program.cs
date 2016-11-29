﻿using AlgoCommonsDotNet.DataStructures.Generic.Arrays;
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
            DynamicArray<int> array = new DynamicArray<int>();

            for (int i = 0; i < 50; i++)
            {
                array.Add(i);
            }

            Console.WriteLine(array.RemoveAt(array.Length - 1));

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
            Console.WriteLine(array.Length);
        }
    }
}
