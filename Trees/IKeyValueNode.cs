namespace Utils.Trees
{
    public interface IKeyValueNode<TKey, out TValue> : IKeyNode<TKey>
    {
        TValue Value { get; }
    }
}