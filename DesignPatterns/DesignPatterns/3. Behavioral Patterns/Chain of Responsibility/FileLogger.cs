using System.IO;

namespace DesignPatterns.ChainOfResponsibility
{
    internal class FileLogger : BaseLogger
    {
        private readonly StreamWriter m_Writer;

        public FileLogger(LogLevel mask, FileStream fileStream)
            : base(mask)
        {
            m_Writer = new StreamWriter(fileStream);
        }

        protected override void PerformLog(string message)
        {
            m_Writer.WriteLine(message);
        }
    }
}