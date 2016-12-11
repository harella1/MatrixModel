using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Iterator
{
    public abstract class BaseTree : IEnumerable<Node>
    {
        private readonly Node m_Root;

        protected BaseTree(Node root)
        {
            m_Root = root;
        }

        protected Node Root
        {
            get { return m_Root; }
        }

        public abstract IEnumerator<Node> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
