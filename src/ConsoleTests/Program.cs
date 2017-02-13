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
            BinarySearchTree<int, int> bst = new BinarySearchTree<int, int>();

            bst.Add(7, 7);
            bst.Add(5, 5);
            bst.Add(12, 12);
            bst.Add(3, 3);
            bst.Add(6, 6);
            bst.Add(9, 9);
            bst.Add(15, 15);
            bst.Add(1, 1);
            bst.Add(4, 4);
            bst.Add(8, 8);
            bst.Add(10, 10);
            bst.Add(13, 13);
            bst.Add(17, 17);

            bst.Remove(7);
            //bst.Add(100, 100);

            Console.WriteLine(bst.Length);
            Console.WriteLine();
        }
    }
}
