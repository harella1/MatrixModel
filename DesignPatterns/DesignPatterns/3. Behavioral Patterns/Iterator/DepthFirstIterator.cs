using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Iterator
{
    public class DepthFirstIterator : IEnumerator<Node>
    {
        private readonly Node m_Root;
        private readonly Stack<Node> m_Stack;
        private Node m_Current;
        private Node m_Next;

        public DepthFirstIterator(Node root)
        {
            m_Root = root;
            m_Next = root;
            m_Stack = new Stack<Node>();
        }

        public bool MoveNext()
        {
            m_Current = m_Next;

            if (m_Current == null)
            {
                if (m_Stack.Count == 0)
                {
                    return false;
                }
                m_Current = m_Stack.Pop();
            }

            if (m_Current.Right != null)
                m_Stack.Push(m_Current.Right);

            m_Next = m_Current.Left;
            return true;
        }

        public void Reset()
        {
            m_Next = m_Root;
            m_Stack.Clear();
        }

        public Node Current
        {
            get { return m_Current; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
        }
    }
}