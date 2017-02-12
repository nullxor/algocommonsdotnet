using System;

namespace AlgoCommonsDotNet.DataStructures.Generic.Trees.BST
{
    /// <summary>
    /// In computer science, binary search trees (BST), sometimes called ordered or
    /// sorted binary trees, are a particular type of containers: data structures that
    /// store "items" (such as numbers, names etc.) in memory. They allow fast lookup,
    /// addition and removal of items, and can be used to implement either dynamic sets
    /// of items, or lookup tables that allow finding an item by its key (e.g., finding 
    /// the phone number of a person by name).
    /// 
    /// Binary search trees keep their keys in sorted order, so that lookup and other 
    /// operations can use the principle of binary search: when looking for a key in a
    /// tree (or a place to insert a new key), they traverse the tree from root to leaf,
    /// making comparisons to keys stored in the nodes of the tree and deciding, based on
    /// the comparison, to continue searching in the left or right subtrees. On average,
    /// this means that each comparison allows the operations to skip about half of the tree,
    /// so that each lookup, insertion or deletion takes time proportional to the logarithm 
    /// of the number of items stored in the tree. This is much better than the linear time
    /// required to find items by key in an (unsorted) array, but slower than the
    /// corresponding operations on hash tables.
    /// 
    /// From Wikipedia.
    /// </summary>
    public class BinarySearchTree<K,V> where K : IComparable<K>
    {
        public long Length { get; private set; }

        /// <summary>
        /// Root node of the tree
        /// </summary>
        private BinaryTreeNode<K,V> _root;

        /// <summary>
        /// Add a new node to the tree
        /// </summary>
        /// <param name="value">Value to add</param>
        public void Add(K key, V value)
        {
            BinaryTreeNode<K,V> cur = _root, prev = null;

            Length++;

            //Find the correct spot to insert the new node
            while (cur != null)
            {
                prev = cur;
                cur = (key.CompareTo(cur.Key) < 0) ? cur.Left : cur.Right;
            }

            var node = new BinaryTreeNode<K,V>(prev, null, null, key, value);

            //The tree was empty
            if (prev == null)
            {
                _root = node;
            }
            else if (key.CompareTo(prev.Key) < 0)
            {
                prev.Left = node;
            }
            else
            {
                prev.Right = node;
            }
        }

        /// <summary>
        /// Set the node value, if the key doesn't exist
        /// a new node is added to the Tree with the given value
        /// </summary>
        public V this[K key]
        {
            get { return Find(key).Value; }
            set { Set(key, value); }
        }

        /// <summary>
        /// Set the node value, if the key doesn't exist
        /// a new node is added to the Tree with the given value
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value to set</param>
        public void Set(K key, V value)
        {
            BinaryTreeNode<K,V> node = FindNode(key);

            if (node == null)
            {
                Add(key, value);
            }
            else
            {
                node.Value = value;
            }
        }

        /// <summary>
        /// Finds a node in the tree
        /// </summary>
        /// <param name="value">Key to search</param>
        /// <returns>Found node, if it could not be found node.HasValue is false</returns>
        public TreeNode<K,V> Find(K key)
        {
            BinaryTreeNode<K,V> node = FindNode(key);

            return new TreeNode<K,V>(GetNodeKey(node), GetNodeValue(node), node != null);
        }

        /// <summary>
        /// Find the Max node in the Tree, this operation is O(h)
        /// thus in a balanced BST the operation takes O(log n)
        /// </summary>
        /// <returns>Max node in the tree or HasValue=false if the tree is empty</returns>
        public TreeNode<K,V> Max()
        {
            BinaryTreeNode<K,V> cur = MaxNode(_root);

            return new TreeNode<K,V>(GetNodeKey(cur), GetNodeValue(cur), cur != null);
        }

        /// <summary>
        /// Find the Min node in the Tree, this operation is O(h)
        /// thus in a balanced BST the operation takes O(log n)
        /// </summary>
        /// <returns>Min node in the tree or HasValue=false if the tree is empty</returns>
        public TreeNode<K,V> Min()
        {
            BinaryTreeNode<K,V> cur = MinNode(_root);

            return new TreeNode<K,V>(GetNodeKey(cur), GetNodeValue(cur), cur != null);
        }

        /// <summary>
        /// Finds the Successor of the given node, for instance, if we have
        /// a tree with the key values {12, 10, 18, 6, 14, 3, 2}
        /// The successor of 2 would be 3
        /// The successor of 12 would be 14
        /// </summary>
        /// <param name="key">Key</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>Successor or HasValue==false if it has not successor</returns>
        public TreeNode<K,V> Successor(K key)
        {
            BinaryTreeNode<K,V> node = FindNode(key);

            if (node == null)
            {
                throw new ArgumentException($"The node with key {key} couldn't be found in the Tree");
            }

            BinaryTreeNode<K,V> succ = SuccessorNode(node);

            return new TreeNode<K,V>(GetNodeKey(succ), GetNodeValue(succ), succ != null);
        }

        /// <summary>
        /// Finds the Predecessor of the given node, for instance, if we have
        /// a tree with the key values {12, 10, 18, 6, 14, 3, 2}
        /// The successor of 3 would be 2
        /// The successor of 14 would be 12
        /// </summary>
        /// <param name="key">Key</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>Successor or HasValue==false if it has not successor</returns>
        public TreeNode<K,V> Predecessor(K key)
        {
            BinaryTreeNode<K,V> node = FindNode(key);

            if (node == null)
            {
                throw new ArgumentException($"The node with key {key} couldn't be found in the Tree");
            }

            BinaryTreeNode<K,V> pred = PredecessorNode(node);

            return new TreeNode<K,V>(GetNodeKey(pred), GetNodeValue(pred), pred != null);
        }

        /// <summary>
        /// Deletes a node from the tree
        /// </summary>
        /// <param name="key">Key of the  node</param>
        /// <returns>true or false  </returns>
        public bool Delete(K key)
        {
            BinaryTreeNode<K, V> node = FindNode(key);

            if (node == null)
            {
                throw new ArgumentException($"The node with key {key} couldn't be found in the Tree");
            }

            //The node to delete has two childs
            if (node.Left != null && node.Right != null)
            {
                //Find the successor
                BinaryTreeNode<K, V> successor = SuccessorNode(node);

                //Replace the content of the node to delete with the content of the successor node
                node.Key = successor.Key;
                node.Value = successor.Value;

                //Delete the successor node
                //The successor is at the botton left of the right child
                //If the right child has not a left child then the successor is the right child itself
                if (node.Right.Left == null)
                {
                    node.Right = node.Right.Right;
                }
                else
                {
                    successor.Parent.Left = null;
                }
            }
            else
            {
                //The node to delete has zero or one child node
                return DeleteNode(node);
            }

            return true;
        }

        /// <summary>
        /// Finds a node in the tree
        /// </summary>
        /// <param name="value">Key to search</param>
        /// <returns>Found node or null</returns>
        private BinaryTreeNode<K,V> FindNode(K key)
        {
            BinaryTreeNode<K,V> cur = _root;

            while ((cur != null) && (key.CompareTo(cur.Key) != 0))
            {
                cur = (key.CompareTo(cur.Key) < 0) ? cur.Left : cur.Right;
            }

            return cur;
        }

        /// <summary>
        /// Find the Max node in the Tree, this operation is O(h)
        /// thus in a balanced BST the operation takes O(log n)
        /// </summary>
        /// <param name="firstNode">Starting node</param>
        /// <returns>Max node in the tree or null if the tree is empty</returns>
        private BinaryTreeNode<K,V> MaxNode(BinaryTreeNode<K,V> firstNode)
        {
            BinaryTreeNode<K,V> cur = firstNode;

            //In a BST the Max element is always to the right of the root
            while ((cur != null) && (cur.Right != null))
            {
                cur = cur.Right;
            }

            return cur;
        }

        /// <summary>
        /// Find the Max node in the Tree, this operation is O(h)
        /// thus in a balanced BST the operation takes O(log n)
        /// </summary>
        /// <param name="firstNode">Starting node</param>
        /// <returns>Min node in the tree or null if the tree is empty</returns>
        private BinaryTreeNode<K,V> MinNode(BinaryTreeNode<K,V> firstNode)
        {
            BinaryTreeNode<K,V> cur = firstNode;

            //In a BST the Max element is always to the left of the root
            while ((cur != null) && (cur.Left != null))
            {
                cur = cur.Left;
            }

            return cur;
        }

        /// <summary>
        /// Finds the successor of the given node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Successor or null it has not any successor</returns>
        private BinaryTreeNode<K,V> SuccessorNode(BinaryTreeNode<K,V> node)
        {
            BinaryTreeNode<K,V> cur = node, parent = node;

            //If the right child is not null, then the successor is the Min node
            //starting from the right child
            if ((cur != null) && (cur.Right != null))
            {
                return MinNode(cur.Right);
            }

            //If the node hasn't a right child, then the successor is upwards
            //and we must search for the top ancestor whose left child is the node
            //that we want to find its successor
            parent = cur.Parent;

            while ((parent != null) && (parent.Right != null) && (parent.Right.Key.CompareTo(cur.Key) == 0))
            {
                cur = parent;
                parent = parent.Parent;
            }

            return parent;
        }

        /// <summary>
        /// Finds the predecessor of the given node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Successor or null it has not any predecessor</returns>
        private BinaryTreeNode<K,V> PredecessorNode(BinaryTreeNode<K,V> node)
        {
            BinaryTreeNode<K,V> cur = node, parent = node;

            //If the left child is not null, then the successor is the Max node
            //starting from the left child
            if ((cur != null) && (cur.Left != null))
            {
                return MaxNode(cur.Left);
            }

            //If the node hasn't a Left child, then the predecessor is upwards
            //and we must search for the top ancestor whose right child is the node
            //that we want to find its predecessor
            parent = cur.Parent;

            while ((parent != null) && (parent.Left != null) && (parent.Left.Key.CompareTo(cur.Key) == 0))
            {
                cur = parent;
                parent = parent.Parent;
            }

            return parent;
        }

        /// <summary>
        /// Deletes a node with zero or one child, by "transplanting" the child
        /// to its parent node, Note: this method only supports these cases
        /// zero or one child
        /// </summary>
        /// <param name="node">Node to delete</param>
        private bool DeleteNode(BinaryTreeNode<K,V> node)
        {
            if (node == null)
            {
                return false;
            }

            var child = node.Left == null ? node.Right : node.Left;
            var parent = node.Parent;

            //We are deleting a node from a Tree with only one node, so we delete the root
            if (parent == null)
            {
                _root = null;
                return true;
            }

            //If the node hasn't children, remove it from its parent
            if (child == null)
            {
                if ((parent.Left != null) && (parent.Left.Key.CompareTo(node.Key) == 0))
                {
                    parent.Left = null;
                }

                if ((parent.Right != null) && (parent.Right.Key.CompareTo(node.Key) == 0))
                {
                    parent.Right = null;
                }

                return true;
            }

            //The node has one child, so makes the parent points to the child
            if ((parent.Left != null) && (parent.Left.Key.CompareTo(node.Key) == 0))
            {
                parent.Left = child;
            }
            else
            {
                parent.Right = child;
            }

            return true;
        }

        /// <summary>
        /// Returns the key from a node or default T if the node is null
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Value from a node or default T if the node is null</returns>
        private K GetNodeKey(BinaryTreeNode<K,V> node)
        {
            return (node != null) ? node.Key : default(K);
        }

        /// <summary>
        /// Returns the value from a node or default T if the node is null
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Value from a node or default T if the node is null</returns>
        private V GetNodeValue(BinaryTreeNode<K,V> node)
        {
            return (node != null) ? node.Value : default(V);
        }

        /// <summary>
        /// A Node for a Binary Tree
        /// </summary>
        private class BinaryTreeNode<K,V> where K : IComparable<K>
        {
            public BinaryTreeNode<K,V> Parent { get; set; }
            public BinaryTreeNode<K,V> Left { get; set; }
            public BinaryTreeNode<K,V> Right { get; set; }
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
        }
    }
}
