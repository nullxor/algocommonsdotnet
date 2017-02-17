using System;
using System.Collections.Generic;

namespace AlgoCommonsDotNet.DataStructures.Generic.Trees.SearchTrees
{
   /*
    * In computer science, binary search trees (BST), sometimes called ordered or
    * sorted binary trees, are a particular type of containers: data structures that
    * store "items" (such as numbers, names etc.) in memory. They allow fast lookup,
    * addition and removal of items, and can be used to implement either dynamic sets
    * of items, or lookup tables that allow finding an item by its key (e.g., finding
    * the phone number of a person by name).
    *
    * Binary search trees keep their keys in sorted order, so that lookup and other
    * operations can use the principle of binary search: when looking for a key in a
    * tree (or a place to insert a new key), they traverse the tree from root to leaf,
    * making comparisons to keys stored in the nodes of the tree and deciding, based on
    * the comparison, to continue searching in the left or right subtrees. On average,
    * this means that each comparison allows the operations to skip about half of the tree,
    * so that each lookup, insertion or deletion takes time proportional to the logarithm
    * of the number of items stored in the tree. This is much better than the linear time
    * required to find items by key in an (unsorted) array, but slower than the
    * corresponding operations on hash tables.
    *
    * From Wikipedia.
    */
    /// <summary>
    /// Binary Search Tree
    /// </summary>
    public class BinarySearchTree<K,V> where K : IComparable<K>
    {
        /// <summary>
        /// Number of nodes in the tree
        /// </summary>
        public long Length { get; private set; }

        /// <summary>
        /// Root node of the tree
        /// </summary>
        protected BinaryTreeNode<K,V> _root;

        /// <summary>
        /// Set the node value, if the key doesn't exist
        /// a new node is added to the Tree with the given value
        /// </summary>
        public V this[K key]
        {
            get
            {
                BinaryTreeNode<K,V> node = Find(key);

                return node != null ? node.Value : default(V);
            }

            set { Set(key, value); }
        }

        /// <summary>
        /// Gets the root of the tree
        /// </summary>
        /// <value>The root</value>
        public KeyValuePair<K,V> Root
        {
            get
            {
                if (_root != null)
                {
                    return new KeyValuePair<K,V>(_root.Key, _root.Value);
                }

                return new KeyValuePair<K,V>();
            }
        }

        /// <summary>
        /// Adds a new node to the tree
        /// </summary>
        /// <param name="value">Value to add</param>
        public virtual void Add(K key, V value)
        {
            BinaryTreeNode<K,V> cur = _root, prev = null;

            Length++;

            //Find the correct spot to insert the new node
            while (cur != null)
            {
                prev = cur;

                //If the key already exists ovewrite it
                if (cur.Key.CompareTo(key) == 0)
                {
                    cur.Value = value;
                    return;
                }

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
        /// Sets the node value, if the key doesn't exist
        /// a new node is added to the Tree with the given value
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value to set</param>
        public void Set(K key, V value)
        {
            BinaryTreeNode<K,V> node = Find(key);

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
        /// Removes a node from the tree
        /// </summary>
        /// <param name="key">Key of the  node</param>
        /// <returns>true or false  </returns>
        public virtual bool Remove(K key)
        {
            BinaryTreeNode<K, V> node = Find(key);

            if (node == null)
            {
                return false;
            }

            Length--;

            //The node has two childs, we have to handle 2 cases
            //1- The successor is the right child of the node we are removing
            //2- The successor is at the bottom left of the right child
            if (node.Left != null && node.Right != null)
            {
                //Find the successor to the bottom left of the right child
                BinaryTreeNode<K, V> successor = Successor(node);

                //Case 1- The successor is the right child of the node we are removing
                if (node.Right.Key.CompareTo(successor.Key) == 0)
                {
                    //Replaces the node to delete with the successor and we're done
                    //We've lost the reference to the successor and it should be swapped
                    //by the GC.

                    //For instance, we have this BST and we want to remove (7) which is the root,
                    //but the same applies to any node with the right child as successor:

                    /*
                     *        (7)
                     *       /   \
                     *     (5)   (8)
                     *              \
                     *              (9)
                     */

                    node.Key = successor.Key;
                    node.Value = successor.Value;
                    node.Right = successor.Right;

                   /* Replace the content of the node to delete with its right
                    * child, but maintain the parent
                    *
                    *        (8)
                    *       /   \
                    *     (5)    \
                    *             \
                    *             (9)
                    */

                    return true;
                }

                //We've reach this point, it means that it's the case 2
                //Case 2- The successor is at the bottom left of the right child
                //Replace the content of the node to remove with its successor,
                //maintaining its parent
                node.Key = successor.Key;
                node.Value = successor.Value;

                //And now make the parent of the successor point to the right
                //subtree of the Successor, let's see this with an ASCII graph

                /* Let's remove (12)
                 *
                 *                    (7)
                 *                   /   \
                 *                 /       \
                 *               /           \
                 *             (5)           (12)
                 *            /   \        /      \
                 *          (3)   (6)    (9)      (15)
                 *         /   \        /   \    /    \
                 *       (1)   (4)    (8)  (10) (13) (17)
                 *                                  \
                 *                                  (14)
                 *
                 *  Replace the node to remove (12) with its successor, in this case
                 *  the successor of (12) is (13), and it's gonna be the last node
                 *  at the bottom left of the right child, so the successor won't have
                 *  a left child but it can have a right child, as we can see with (13)
                 *  or it could be a subtree aswell, so we need to make that the parent
                 *  of the successor -(15) in this case- points to its right child or subtree,
                 *  now (15).Left points to (14) and (14).Parent points to (15).
                 *
                 *  This works even if the node to delete is the root.
                 *
                 *                    (7)
                 *                   /   \
                 *                 /       \
                 *               /           \
                 *             (5)           (13)
                 *            /   \        /      \
                 *          (3)   (6)    (9)      (15)
                 *         /   \        /   \    /    \
                 *       (1)   (4)    (8)  (10)   \   (17)
                 *                                  \
                 *                                  (14)
                 */

                //Fix the parent if the successor has a right node or subtree

                if (successor.Right != null)
                {
                    successor.Right.Parent = successor.Parent;
                }

                successor.Parent.Left = successor.Right;
            }
            else
            {
                //The node to delete has zero or one child
                return Delete(node);
            }

            return false;
        }

        /// <summary>
        /// Finds the item with the Max key in the tree
        /// </summary>
        /// <returns>KeyValuePair</returns>
        public KeyValuePair<K,V> MaxKey()
        {
            BinaryTreeNode<K,V> max = Max(_root);

            return new KeyValuePair<K, V>(max.Key, max.Value);
        }

        /// <summary>
        /// Finds the item with the Min key in the tree
        /// </summary>
        /// <returns>KeyValuePair</returns>
        public KeyValuePair<K,V> MinKey()
        {
            BinaryTreeNode<K,V> min = Min(_root);

            return new KeyValuePair<K, V>(min.Key, min.Value);
        }

        /// <summary>
        /// Finds the successor of the given key
        /// </summary>
        /// <returns>KeyValuePair</returns>
        public KeyValuePair<K,V> SuccessorKey(K key)
        {
            BinaryTreeNode<K,V> node = Find(key);

            if (node == null)
            {
                throw new ArgumentException($"The key {key} doesn't exist");
            }

            var succ = Successor(node);

            //There is no successor, the key is the max
            if (succ == null)
            {
                return new KeyValuePair<K, V>(node.Key, node.Value);
            }

            return new KeyValuePair<K, V>(succ.Key, succ.Value);
        }

        /// <summary>
        /// Finds the predecessor of the given key
        /// </summary>
        /// <returns>KeyValuePair</returns>
        public KeyValuePair<K,V> PredecessorKey(K key)
        {
            BinaryTreeNode<K,V> node = Find(key);

            if (node == null)
            {
                throw new ArgumentException($"The key {key} doesn't exist");
            }

            var pred = Predecessor(node);

            //There is no successor, the key is the max
            if (pred == null)
            {
                return new KeyValuePair<K, V>(node.Key, node.Value);
            }

            return new KeyValuePair<K, V>(pred.Key, pred.Value);
        }

        /// <summary>
        /// Determines if the item with the given key is the root of the tree
        /// </summary>
        /// <returns>true if it's the root otherwise false</returns>
        /// <param name="key">Key.</param>
        public bool IsRoot(K key)
        {
            return _root?.Key.CompareTo(key) == 0;
        }

        /// <summary>
        /// Finds a node in the tree
        /// </summary>
        /// <param name="value">Key to search</param>
        /// <returns>Found node or null</returns>
        protected virtual BinaryTreeNode<K,V> Find(K key)
        {
            BinaryTreeNode<K,V> cur = _root;

            while ((cur != null) && (key.CompareTo(cur.Key) != 0))
            {
                cur = (key.CompareTo(cur.Key) < 0) ? cur.Left : cur.Right;
            }

            return cur;
        }

        /// <summary>
        /// Finds the Max node in the Tree, this operation is O(h)
        /// thus in a balanced BST the operation takes O(log n)
        /// </summary>
        /// <param name="firstNode">Starting node</param>
        /// <returns>Max node in the tree or null if the tree is empty</returns>
        protected virtual BinaryTreeNode<K,V> Max(BinaryTreeNode<K,V> firstNode)
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
        /// Finds the Max node in the Tree, this operation is O(h)
        /// thus in a balanced BST the operation takes O(log n)
        /// </summary>
        /// <param name="firstNode">Starting node</param>
        /// <returns>Min node in the tree or null if the tree is empty</returns>
        protected BinaryTreeNode<K,V> Min(BinaryTreeNode<K,V> firstNode)
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
        protected BinaryTreeNode<K,V> Successor(BinaryTreeNode<K,V> node)
        {
            BinaryTreeNode<K,V> cur = node, parent = node;

            //If the right child is not null, then the successor is the Min node
            //starting from the right child
            if ((cur != null) && (cur.Right != null))
            {
                return Min(cur.Right);
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
        /// <returns>Successor or null if there is no any predecessor</returns>
        protected BinaryTreeNode<K,V> Predecessor(BinaryTreeNode<K,V> node)
        {
            BinaryTreeNode<K,V> cur = node, parent = node;

            //If the left child is not null, then the successor is the Max node
            //starting from the left child
            if ((cur != null) && (cur.Left != null))
            {
                return Max(cur.Left);
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
        /// to its parent node, Note: this method only supports cases with
        /// zero or one child
        /// </summary>
        /// <param name="node">Node to delete</param>
        protected bool Delete(BinaryTreeNode<K,V> node)
        {
            if (node == null)
            {
                return false;
            }

            var child = node.Left == null ? node.Right : node.Left;
            var parent = node.Parent;

            //We are removing the root
            if (parent == null)
            {
                //We are removing the root, it can have 0 or 1 child
                _root = child;

                if (_root != null)
                {
                    _root.Parent = null; //Fix the parent
                }

                return true;
            }

            //Is not the root

            //Fix the parent
            if (child != null)
            {
                child.Parent = parent;
            }

            //Make the parent points to the correct child, it could be null if the node
            //to remove hasn't any child
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
    }
}
