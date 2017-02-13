using AlgoCommonsDotNet.Algorithms.Sorting;
using AlgoCommonsDotNet.DataStructures.Generic.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoCommonsDotNet.DataStructures.Generic.Trees.BST;

namespace ConsoleTests
{
    /// <summary>
    /// General tests
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int, string> bst = new BinarySearchTree<int, string>();


            bst.Add(7, "Siete");
            bst.Add(5, "5");
            bst.Add(12, "Twelve");
            bst.Add(3, "Three");
            bst.Add(6, "Six");
            bst.Add(9, "Nine");
            bst.Add(15, "Quince");
            bst.Add(1, "One");
            bst.Add(4, "4");
            bst.Add(8, "8");
            bst.Add(10, "10");
            bst.Add(13, "13");
            bst.Add(17, "17");

            Console.WriteLine(bst.PredecessorKey(7));

            Console.WriteLine();
        }
    }
}
