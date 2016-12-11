using System;

namespace DesignPatterns.ChainOfResponsibility
{
    [Flags]
    public enum LogLevel
    {
        None = 0x00,
        Info = 0x01,
        Warning = 0x02,
        Error = 0x04,
    }
}