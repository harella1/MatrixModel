using System;

namespace DesignPatterns.Observer
{
    public class ObserverSubscribtionException : InvalidOperationException
    {
        public ObserverSubscribtionException(string message)
            : base(message)
        {
        }
    }
}