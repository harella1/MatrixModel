using System;

namespace DesignPatterns.Memento
{
    public class IncompatibleMementoException : InvalidOperationException
    {
        public IncompatibleMementoException(string message, InvalidCastException innerException)
            : base(message, innerException)
        {
        }
    }
}