namespace DesignPatterns.ChainOfResponsibility
{
    public interface ILogger
    {
        void SetNext(ILogger nextlogger);
        void Log(string message, LogLevel severity);
    }
}