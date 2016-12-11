using System;
using System.Threading;

namespace DesignPatterns.Interpreter
{
    public class BeepPlayer : Player
    {
        public override void Init()
        {
            
        }

        protected override void PlayPause(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        protected override void PlaySound(int milliseconds, int stepsToA4)
        {
            if (milliseconds == 0) return;
            double frequency = GetFrequency(stepsToA4);
            var intFrequency = (int)Math.Round(frequency, 0);
            Console.Beep(intFrequency, milliseconds);   
        }

        public override void Dispose()
        {
            
        }

        public const double FrequencyOfMiddleA = 440;
        public double TwelthRootOf2 = Math.Pow(2.0, 1.0 / 12.0);
        private double GetFrequency(int stepsToA4)
        {
            return FrequencyOfMiddleA * Math.Pow(TwelthRootOf2, stepsToA4);
        }
    }
}