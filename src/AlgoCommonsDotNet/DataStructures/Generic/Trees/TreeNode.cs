namespace AlgoCommonsDotNet.DataStructures.Generic.Trees
{
    /// <summary>
    /// A result node for a tree
    /// </summary>
    public class TreeNode<K, V>
    {
        public bool HasValue { get; private set; }
        public K Key { get; private set; }
        public V Value { get; private set; }

        public TreeNode(K key, V value, bool hasValue)
        {
            Key = key;
            Value = value;
            HasValue = hasValue;
        }
    }
}
