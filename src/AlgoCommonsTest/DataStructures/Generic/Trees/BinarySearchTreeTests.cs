using System;
using NUnit.Framework;
using AlgoCommonsDotNet.DataStructures.Generic.Trees.SearchTrees;

namespace AlgoCommonsTest
{
    /// <summary>
    /// BinarySearchTree tests
    /// </summary>
    [TestFixture]
    public class BinarySearchTreeTests
    {
        /* We'll use this BST for testing
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
         */

        BinarySearchTree<int, int> _bst;
        const int BstLengthExpected = 13;

        [SetUp]
        public void SetUp()
        {
            _bst = new BinarySearchTree<int, int>();
            _bst.Add(7, 7);
            _bst.Add(5, 5);
            _bst.Add(12, 12);
            _bst.Add(3, 3);
            _bst.Add(6, 6);
            _bst.Add(9, 9);
            _bst.Add(15, 15);
            _bst.Add(1, 1);
            _bst.Add(4, 4);
            _bst.Add(8, 8);
            _bst.Add(10, 10);
            _bst.Add(13, 13);
            _bst.Add(17, 17);
        }

        [Test]
        public void ShouldReturnTheCorrectLength()
        {
            Assert.AreEqual(BstLengthExpected, _bst.Length);
        }

        [Test]
        public void ShouldReturnTheCorrectLengthAfterRemoving()
        {
            _bst.Remove(5);
            Assert.AreEqual(BstLengthExpected - 1, _bst.Length);
        }

        [Test]
        public void ShouldThrowExceptionWhenAddingExistingKey()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _bst.Add(1, 1);
            });
        }

        [Test]
        public void ShouldReturnTheCorrectLengthAfterAdding()
        {
            _bst.Add(1000, 1000);
            Assert.AreEqual(BstLengthExpected + 1, _bst.Length);
        }

        [Test]
        public void ShouldReturnTheCorrectRoot()
        {
            Assert.AreEqual(_bst.Root.Value.Key, 7);
        }

        [Test]
        public void ShouldReturnTheCorrectRootAfterDeleteTheRoot()
        {
            //This explanation is a bit tricky, but I'll do my best

            //If we remove the root, then we would have the case of a node with 2 children
            //In this case we'll find the successor and replace the root to delete with the successor
            //If the successor has a right subtree, then we transplant all the right subtree to the
            //Left of the successor parent

            //In short words in this case if we delete the root 7 the new root should be 8
            _bst.Remove(_bst.Root.Value.Key);
            Assert.AreEqual(_bst.Root.Value.Key, 8);

            //If we delete again, the new root would be 9 (Successor of 8) and because (9) has a 
            //right child (10) we must to transplant (10) to the left of the parent of (9) in this case (12)
        }

        [Test]
        public void ShouldRemove()
        {
            _bst.Remove(6);
            Assert.AreEqual(0, _bst[6]);
        }

        [Test]
        public void ShouldAddWithIndexerIfDoesNotExist()
        {
            _bst[50] = 50;
            Assert.AreEqual(50, _bst[50]);
        }

        [Test]
        public void ShouldOvewriteWithIndexerIfDoesExist()
        {
            _bst[8] = 50;
            Assert.AreEqual(50, _bst[8]);
        }

        [Test]
        public void ShouldFindMinKey()
        {
            Assert.AreEqual(1, _bst.MinKey().Key);
        }

        [Test]
        public void ShouldFindMaxKey()
        {
            Assert.AreEqual(17, _bst.MaxKey().Key);
        }

        [Test]
        public void ShouldFindSuccessor()
        {
            Assert.AreEqual(9, _bst.Successor(8).Key);
        }

        [Test]
        public void ShouldFindPredecessor()
        {
            Assert.AreEqual(7, _bst.Predecessor(8).Key);
        }
    }
}