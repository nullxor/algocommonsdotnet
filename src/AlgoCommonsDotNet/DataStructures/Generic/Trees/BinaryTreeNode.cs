using System;

namespace AlgoCommonsDotNet.DataStructures.Generic.Trees
{
    /// <summary>
    /// A Node for a Binary Tree
    /// </summary>
    public class BinaryTreeNode<K,V> where K : IComparable<K>
    {
        public virtual BinaryTreeNode<K,V> Parent { get; set; }
        public virtual BinaryTreeNode<K,V> Left { get; set; }
        public virtual BinaryTreeNode<K,V> Right { get; set; }
        public K Key { get; set; }
        public V Value { get; set; }

        public BinaryTreeNode(BinaryTreeNode<K,V> parent, BinaryTreeNode<K,V> left, BinaryTreeNode<K,V> right, K key, V value)
        {
            Parent = parent;
            Left = left;
            Right = right;
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Checks if the given node is the parent's left child
        /// </summary>
        /// <returns>true if it's the left child otherwise false</returns>
        public bool IsLeftChild()
        {
            return Parent != null && Parent.Left == this;
        }

        /// <summary>
        /// Checks if the given node is the root of the tree
        /// </summary>
        /// <returns>true if it's the root otherwise false</returns>
        public bool IsRightChild()
        {
            return Parent != null && Parent.Right == this;
        }
    }
}
 