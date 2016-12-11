using System.IO;
using DesignPatterns.ChainOfResponsibility;

namespace DesignPatterns
{
    public partial class Program
    {
        public static void ChainOfResponsibility()
        {
            using (FileStream tempFileStream = File.Create(Path.GetTempFileName()))
            {
                ILogger consoleLogger = new ConsoleLogger(LogLevel.Info | LogLevel.Warning | LogLevel.Error);
                ILogger memoryLogger = new MemoryQueueLogger(LogLevel.Warning | LogLevel.Error);

                ILogger fileLogger = new FileLogger(LogLevel.Error, tempFileStream);

                ILogger logger = consoleLogger;
                consoleLogger.SetNext(memoryLogger);
                memoryLogger.SetNext(fileLogger);

                logger.Log("This entry arrives only to ConsoleLogger.", LogLevel.Info);
                logger.Log("This entry arrives to ConsoleLogger and MemoryQueueLogger.", LogLevel.Warning);
                logger.Log("This entry arrives to ConsoleLogger, MemoryQueueLogger and FileLogger.", LogLevel.Error);
            }
        }
    }
}