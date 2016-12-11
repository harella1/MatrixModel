using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Strategy
{
    /// <summary>
    ///     A collection implementation which uses array as underlaing data structure.
    ///     Resizing the array is performed by a <see cref="IResizer" /> strategy,
    ///     which gets injected in constructor. This allows to exchange it depending
    ///     weather a memory or runtime optimized approach is needed.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayBasedCollection<T> : ICollection<T>
    {
        private readonly IResizer m_Resizer;
        private T[] m_InnerArray;

        public ArrayBasedCollection(IResizer resizer)
        {
            m_Resizer = resizer;
            int initialCapacity = m_Resizer.InitialCapacity;
            m_InnerArray = new T[initialCapacity];
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return m_InnerArray.Cast<T>().GetEnumerator();
        }

        public void Add(T item)
        {
            m_Resizer.OnAdd(ref m_InnerArray, Count + 1);
            m_InnerArray[Count] = item;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
            m_Resizer.OnRemove(ref m_InnerArray, Count);
        }

        public bool Contains(T item)
        {
            int index = Array.IndexOf(m_InnerArray, item);
            return index >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(m_InnerArray, 0, array, arrayIndex, Count);
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(m_InnerArray, item);
            bool found = index >= 0;
            if (found) RemoveAt(index);
            return found;
        }

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get { return false; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_InnerArray.GetEnumerator();
        }

        private void RemoveAt(int index)
        {
            for (int i = index; i + 1 < Count; i++)
            {
                m_InnerArray[i] = m_InnerArray[i + 1];
            }
            Count--;
            m_Resizer.OnRemove(ref m_InnerArray, Count);
        }
    }
}