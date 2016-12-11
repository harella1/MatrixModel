namespace DesignPatterns.ChainOfResponsibility
{
    public abstract class BaseLogger : ILogger
    {
        private readonly LogLevel m_Mask;
        private ILogger m_Next;

        protected BaseLogger(LogLevel mask)
        {
            m_Mask = mask;
        }

        protected ILogger Next
        {
            get { return m_Next; }
        }

        public void SetNext(ILogger nextlogger)
        {
            m_Next = nextlogger;
        }

        public void Log(string message, LogLevel severity)
        {
            if ((severity & m_Mask) != LogLevel.None)
            {
                PerformLog(message);
            }
            if (m_Next == null) return;
            m_Next.Log(message, severity);
        }

        protected abstract void PerformLog(string message);
    }
}