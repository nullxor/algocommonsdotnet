using System;

namespace AlgoCommonsDotNet.DataStructures.Generic.Trees
{
    /// <summary>
    /// A Node for a Red black tree, it's a wrapper of a BinaryTreeNode
    /// </summary>
    public class RedBlackTreeNode <K,V> where K : IComparable<K>
    {
        public BinaryTreeNode<K,V> Data { get; set; }

        /// <summary>
        /// False by default, new nodes should be red
        /// </summary>
        public bool IsBlack { get; set; }

        public RedBlackTreeNode(BinaryTreeNode<K,V> data, bool isBlack = false)
        {
            Data = data;
            IsBlack = isBlack;
        }
    }
}
