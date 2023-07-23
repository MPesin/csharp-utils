using System;
using System.Collections.Generic;

namespace Utils.Trees
{
    public interface IKeyNode<T>
    {
        IKeyNode<T> Parent { get; }
        
        T Key { get; }

        bool ChildExists(T key);

        /// <summary>
        ///  Adds <paramref name="node"/> as child and changes it's parent to be <c>this</c>
        /// </summary>
        void AppendChild(IKeyNode<T> node);

        IKeyNode<T> AddChild(T key);

        /// <exception cref="InvalidOperationException">Child with key <paramref name="key"/> doesn't exist</exception>
        void RemoveChild(T key);

        /// <exception cref="InvalidOperationException">Child with key <paramref name="key"/> doesn't exist</exception>
        IKeyNode<T> FindChild(T key);

        IEnumerable<IKeyNode<T>> GetAllChildren();
        
        void SetParent(KeyNode<T> newParent);
    }
}