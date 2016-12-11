using System;
using System.Threading;

namespace DesignPatterns.Observer
{
    public class TimePulseObservable : Observable<DateTime>
    {
        public TimePulseObservable(TimeSpan timeSpan)
        {
            var timer = new Timer(state => NotifyObservers(DateTime.Now));
            timer.Change(timeSpan, timeSpan);
        }
    }
}