using System;

namespace DesignPatterns.Observer
{
    public class TimePulseWriter : IObserver<DateTime>
    {
        public void OnNotified(DateTime message)
        {
            Console.WriteLine("Pulse at: {0}", message);
        }
    }
}