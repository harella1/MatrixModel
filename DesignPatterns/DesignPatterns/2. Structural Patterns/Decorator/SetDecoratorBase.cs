using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Decorator
{
    public abstract class SetDecoratorBase<T> : ISet<T>
    {
        private readonly ISet<T> m_Set;

        protected SetDecoratorBase(ISet<T> set)
        {
            m_Set = set;
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return m_Set.GetEnumerator();
        }

        void ICollection<T>.Add(T item)
        {
            m_Set.Add(item);
        }

        public virtual void Clear()
        {
            m_Set.Clear();
        }

        public virtual bool Contains(T item)
        {
            return m_Set.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            m_Set.CopyTo(array, arrayIndex);
        }

        public virtual bool Remove(T item)
        {
            return m_Set.Remove(item);
        }

        public int Count
        {
            get { return m_Set.Count; }
        }

        public virtual bool IsReadOnly
        {
            get { return m_Set.IsReadOnly; }
        }

        public virtual bool Add(T item)
        {
            return m_Set.Add(item);
        }

        public void UnionWith(IEnumerable<T> other)
        {
            ThrowNotSupportedDueToSimplification();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            ThrowNotSupportedDueToSimplification();
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            ThrowNotSupportedDueToSimplification();
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            return m_Set.IsSubsetOf(other);
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            ThrowNotSupportedDueToSimplification();
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            return m_Set.IsSupersetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return m_Set.IsProperSupersetOf(other);
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return m_Set.IsProperSubsetOf(other);
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            return m_Set.Overlaps(other);
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            return m_Set.SetEquals(other);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private static void ThrowNotSupportedDueToSimplification()
        {
            throw new NotSupportedException("This method is not supported due to simplification of example code.");
        }
    }
}