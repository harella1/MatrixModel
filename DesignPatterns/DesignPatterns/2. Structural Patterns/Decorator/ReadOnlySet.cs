using System.Collections.Generic;
using System.Data;

namespace DesignPatterns.Decorator
{
    public class ReadOnlySet<T> : SetDecoratorBase<T>
    {
        public ReadOnlySet(ISet<T> set) : base(set)
        {
        }

        public override bool IsReadOnly
        {
            get { return true; }
        }

        public override bool Add(T item)
        {
            throw new ReadOnlyException();
        }

        public override void Clear()
        {
            throw new ReadOnlyException();
        }

        public override bool Remove(T item)
        {
            throw new ReadOnlyException();
        }
    }
}