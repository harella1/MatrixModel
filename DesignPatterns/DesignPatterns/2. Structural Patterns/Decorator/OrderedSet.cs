using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Decorator
{
    public class OrderedSet<T> : SetDecoratorBase<T>
    {
        private readonly Stack<WeakReference> m_Stack;

        public OrderedSet(ISet<T> set) : base(set)
        {
            if (set.Count != 0)
                throw new NotSupportedException("Only an empty set can be decorated into an ordered set.");
            m_Stack = new Stack<WeakReference>();
        }

        public override bool Add(T item)
        {
            var itemRef = new WeakReference(item);
            m_Stack.Push(itemRef);
            return base.Add(item);
        }

        public override void Clear()
        {
            m_Stack.Clear();
            base.Clear();
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return
                m_Stack
                    .Where(itemRef => itemRef.IsAlive)
                    .Select(itemRef => itemRef.Target)
                    .Cast<T>()
                    .Where(item => Contains(item))
                    .GetEnumerator();
        }
    }
}