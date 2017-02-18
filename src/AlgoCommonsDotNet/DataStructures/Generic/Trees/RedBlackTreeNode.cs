using System;

namespace AlgoCommonsDotNet.DataStructures.Generic.Trees
{
    /// <summary>
    /// A Node for a Red Black Tree
    /// </summary>
    public class RedBlackTreeNode <K,V> : BinaryTreeNode<K,V> where K : IComparable<K>
    {
        /// <summary>
        /// Is a black or red node, false by default, new nodes should be red
        /// </summary>
        public NodeColor Color { get; set; }

        public RedBlackTreeNode(BinaryTreeNode<K,V> parent, BinaryTreeNode<K,V> left, 
            BinaryTreeNode<K,V> right, K key, V value, NodeColor color = NodeColor.Black) :
        base(parent, left, right, key, value)

        {
            Color = color;
        }
    }

    /// <summary>
    /// Red black tree node color
    /// </summary>
    public enum NodeColor { Black, Red };
}

