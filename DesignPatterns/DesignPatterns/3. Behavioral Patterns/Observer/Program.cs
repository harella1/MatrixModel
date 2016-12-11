using System;
using DesignPatterns.Observer;

namespace DesignPatterns
{
    public partial class Program
    {
        public static void Observer()
        {
            var fievSeconds = new TimeSpan(0, 0, 5);
            var pulseObservable = new TimePulseObservable(fievSeconds);
            Console.WriteLine("························ Initialize time pulse with 5 seconds");

            var pulseWriter = new TimePulseWriter();
            pulseObservable.Subscribe(pulseWriter);
            Console.WriteLine("························ Subscribed pulse writer");

            var pulseBeeper = new TimePulseBeeper();
            pulseObservable.Subscribe(pulseBeeper);
            Console.WriteLine("························ Subscribed pulse beeper");

            Console.WriteLine("························ Unmute speakers and wait 5 seconds ...");
        }
    }
}