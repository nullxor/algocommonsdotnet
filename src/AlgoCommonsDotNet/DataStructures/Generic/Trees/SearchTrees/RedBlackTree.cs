using System;
using AlgoCommonsDotNet.DataStructures.Generic.Trees;

namespace AlgoCommonsDotNet.DataStructures.Generic.Trees.SearchTrees
{
    public class RedBlackTree<K,V> : BinarySearchTree<K,V> where K : IComparable<K>
    {
        public override void Add(K key, V value)
        {
            var newNode = new RedBlackTreeNode<K,V>(null, null, null, key, value);

            newNode.Parent = AddNode(newNode);
            Length++;

            if (newNode.Parent != null && ((RedBlackTreeNode<K,V>)newNode.Parent).Color == NodeColor.Red)
            {
                FixAfterInsertion(newNode);
            }

            //Root always must be black
            ((RedBlackTreeNode<K,V>)_root).Color = NodeColor.Black;
        }

        protected void FixAfterInsertion(RedBlackTreeNode<K,V> node)
        {
            if (node == null || node.Parent == null || node.Parent.Parent == null)
            {
                return;
            }

            //There are 2 probable issues to fix after insertion
            //And all of them must have 2 red nodes (child, parent) AKA red red problem

            //Legend:
            //(N) = New Node (P) = Parent (S) = Sibling (Uncle) (G) = Grandparent

            var sibling = GetSibling((RedBlackTreeNode<K,V>)node.Parent);
            bool parentIsRed = ((RedBlackTreeNode<K,V>)node.Parent).Color == NodeColor.Red;
            NodeColor siblingColor = sibling != null ? sibling.Color : NodeColor.Black;

            //Case 1: (N) == Red && (P) == Red && (S) == Red
            //In this case we recolor and go upwards
            if (parentIsRed && sibling != null && sibling.Color == NodeColor.Red)
            {
                ((RedBlackTreeNode<K,V>)node.Parent.Parent).Color = NodeColor.Red;
                ((RedBlackTreeNode<K,V>)node.Parent).Color = NodeColor.Black;
                sibling.Color = NodeColor.Black;

                FixAfterInsertion((RedBlackTreeNode<K,V>)node.Parent.Parent);
            }
            //Case 2: (N) == Red && (P) == Red && (S) == Black (null siblings are black too)

            //It's a bit tricky to explain in comments
            //For more info about the cases: https://brilliant.org/wiki/red-black-tree/
            else if (parentIsRed && siblingColor == NodeColor.Black)
            {
                var grandparent = node.Parent.Parent;
                ((RedBlackTreeNode<K,V>)node.Parent.Parent).Color = NodeColor.Red;

                //Case 2.1
                if (node.Parent.IsLeftChild() && node.IsLeftChild())
                {
                    ((RedBlackTreeNode<K,V>)node.Parent).Color = NodeColor.Black;
                    RotateRight(grandparent);
                }

                //Case 2.2
                else if (node.Parent.IsLeftChild() && node.IsRightChild())
                {
                    node.Color = NodeColor.Black;
                    RotateLeft(node.Parent);
                    RotateRight(grandparent);
                }

                //Case 2.3
                else if (node.Parent.IsRightChild() && node.IsRightChild())
                {
                    ((RedBlackTreeNode<K,V>)node.Parent).Color = NodeColor.Black;
                    RotateLeft(grandparent);
                }

                //Case 2.4
                else if (node.Parent.IsRightChild() && node.IsLeftChild())
                {
                    node.Color = NodeColor.Black;
                    RotateRight(node.Parent);
                    RotateLeft(grandparent);
                }
            }
        }

        /// <summary>
        /// Gets the sibling of the given node
        /// </summary>
        /// <returns>The sibling</returns>
        /// <param name="node">Node</param>
        protected RedBlackTreeNode<K,V> GetSibling(RedBlackTreeNode<K,V> node)
        {
            if (node.IsRightChild())
            {
                return (RedBlackTreeNode<K,V>) node.Parent.Left;
            }

            return (RedBlackTreeNode<K,V>)node.Parent.Right;
        }
    }
}

