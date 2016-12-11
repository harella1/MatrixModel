using System.Collections.Generic;

namespace DesignPatterns.Command
{
    public class FileOperationInvoker
    {
        private readonly Queue<ICommand> m_CommandQueue;

        public FileOperationInvoker()
        {
            m_CommandQueue = new Queue<ICommand>();
        }

        public void Enqueue(ICommand command)
        {
            m_CommandQueue.Enqueue(command);
        }

        public void InvokeAll()
        {
            while (m_CommandQueue.Count > 0)
            {
                ICommand command = m_CommandQueue.Dequeue();
                command.Execute();
            }
        }
    }
}