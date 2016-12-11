using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Iterator
{
    public class BreadthFirstIterator : IEnumerator<Node>
    {
        private readonly Queue<Node> m_Queue;
        private readonly Node m_Root;
        private Node m_Current;

        public BreadthFirstIterator(Node root)
        {
            m_Root = root;
            m_Queue = new Queue<Node>();
            m_Queue.Enqueue(m_Root);
        }

        public bool MoveNext()
        {
            do
            {
                if (m_Queue.Count == 0) return false;
                m_Current = m_Queue.Dequeue();
            } while (m_Current == null);

            m_Queue.Enqueue(m_Current.Left);
            m_Queue.Enqueue(m_Current.Right);
            return true;
        }

        public void Reset()
        {
            m_Queue.Clear();
            m_Queue.Enqueue(m_Root);
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