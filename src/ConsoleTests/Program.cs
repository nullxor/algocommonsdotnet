using AlgoCommonsDotNet.DataStructures.Generic.Trees;
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
            int[] array = { 3, 8, 5, 17, 13, 25 };
            HeapBase<int> heap = new MaxHeap<int>(array);

            array = heap.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(heap.RemoveTop());
            }

            Console.WriteLine("");
        }
    }
}
