﻿using System;
using AlgoCommonsDotNet.DataStructures.Generic.Trees.SearchTrees;

namespace AlgoCommonsDotNet
{
    public class RedBlackTree<K,V> : BinarySearchTree<K,V> where K : IComparable<K>
    {
        public override void Add(K key, V value)
        {
            base.Add(key, value);
        }
    }
}

