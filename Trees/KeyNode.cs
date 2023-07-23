using System;
using System.Collections.Generic;

namespace Utils.Trees
{
    public class KeyNode<T> : IKeyNode<T>
    {
        private readonly object _lock = new();
        private readonly IDictionary<T, IKeyNode<T>> _children;

        public KeyNode(IKeyNode<T> parent, T key)
        {
            Parent = parent;
            Key = key;
            _children = new Dictionary<T, IKeyNode<T>>();
        }

        public IKeyNode<T> Parent { get; private set; }
        
        public T Key { get; }
        
        public bool ChildExists(T value)
        {
            lock (_lock)
            {
                return _children.ContainsKey(value);
            }
        }

        public void AppendChild(IKeyNode<T> node)
        {
            lock (_lock)
            {
                node.SetParent(this);
                _children[node.Key] = node;
            }
        }

        public IKeyNode<T> AddChild(T key)
        {
            lock (_lock)
            {
                var node = new KeyNode<T>(this, key);
                _children[key] = node;
                return node;
            }
        }

        public void RemoveChild(T key)
        {
            lock (_lock)
            {
                ValidateExists(key);
                _children.Remove(key);
            }
        }

        public IKeyNode<T> FindChild(T key)
        {
            lock (_lock)
            {
                ValidateExists(key);
                return _children[key];
            }
        }

        private void ValidateExists(T key)
        {
            if (!_children.ContainsKey(key))
                throw new InvalidOperationException($"{key} doesn't exist");
        }

        public IEnumerable<IKeyNode<T>> GetAllChildren()
        {
            lock (_lock)
            {
                return _children.Values;
            }
        }

        public void SetParent(KeyNode<T> newParent)
        {
            Parent = newParent;
        }
    }
}