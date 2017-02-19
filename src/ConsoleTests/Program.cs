using AlgoCommonsDotNet.Algorithms.Sorting;
using AlgoCommonsDotNet.DataStructures.Generic.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoCommonsDotNet.DataStructures.Generic.Trees.SearchTrees;
using AlgoCommonsDotNet.DataStructures.Generic.Trees;

namespace ConsoleTests
{
    /// <summary>
    /// General tests
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            RedBlackTree<int, int> bst = new RedBlackTree<int, int>();

            bst.Add(8, 8);
            bst.Add(18, 18);
            bst.Add(5, 5);
            bst.Add(15, 15);
            bst.Add(17, 17);
            bst.Add(25, 25);
            bst.Add(40, 40);
            bst.Add(80, 80);

            bst.InOrderTraversal((k, v) =>
            {
                Console.Write("{0}, ", k);
            });

            //bst.Remove(80);
            Console.WriteLine(bst.Successor(18));
        }
    }
}
