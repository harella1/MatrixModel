using System;

namespace DesignPatterns.Observer
{
    public class TimePulseBeeper : IObserver<DateTime>
    {
        public void OnNotified(DateTime message)
        {
            Console.Beep();
        }
    }
}