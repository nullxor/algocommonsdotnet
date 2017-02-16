using System;

namespace AlgoCommonsDotNet.DataStructures.Generic.Trees
{
    /// <summary>
    /// A Node for a Binary Tree
    /// </summary>
    public class RedBlackTreeNode <K,V> : BinaryTreeNode<K,V> where K : IComparable<K>
    {
        /// <summary>
        /// Is a black or red node, false by default, new nodes should be red
        /// </summary>
        public bool IsBlack { get; set; }

        public RedBlackTreeNode(BinaryTreeNode<K,V> parent, BinaryTreeNode<K,V> left, 
            BinaryTreeNode<K,V> right, K key, V value, bool isBlack = false) :
        base(parent, left, right, key, value)

        {
            IsBlack = isBlack;
        }
    }
}

