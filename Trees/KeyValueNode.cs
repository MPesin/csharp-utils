namespace Utils.Trees
{
    public class KeyValueNode<TKey, TValue> : KeyNode<TKey>, IKeyValueNode<TKey, TValue>
    {
        public KeyValueNode(IKeyNode<TKey> parent, TKey key, TValue value) : base(parent, key)
        {
            Value = value;
        }

        public TValue Value { get; }
    }
}