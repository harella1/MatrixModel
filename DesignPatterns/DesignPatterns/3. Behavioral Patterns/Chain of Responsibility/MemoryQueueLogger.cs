using System.Collections.Generic;

namespace DesignPatterns.ChainOfResponsibility
{
    internal class MemoryQueueLogger : BaseLogger
    {
        private readonly Queue<string> m_Queue;

        public MemoryQueueLogger(LogLevel mask)
            : base(mask)
        {
            m_Queue = new Queue<string>();
        }

        protected override void PerformLog(string message)
        {
            m_Queue.Enqueue(message);
        }

        public string Dequeue()
        {
            return m_Queue.Dequeue();
        }
    }
}