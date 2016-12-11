using System;

namespace DesignPatterns.Interpreter
{
    public abstract class Player : IDisposable
    {
        public void Play(ContextState state)
        {
            var currentTotalLength = GetTotalDuration(state);
            int soundDuration;
            int pauseDuration;
            GetDurations(currentTotalLength, state.Duration, out soundDuration, out pauseDuration);

            int stepsToA4 = StepsToA4(state.Octave, state.Note, state.Accidental);

            PlaySound(soundDuration, stepsToA4);
            PlayPause(pauseDuration);
        }

        public abstract void Init();

        private int GetTotalDuration(ContextState state)
        {
            var oneMinute = new TimeSpan(0, 1, 0);
            int l4TotalLength = (int)oneMinute.TotalMilliseconds/state.Tempo;
            int l1TotalLength = l4TotalLength*4;
            int currentTotalLength = l1TotalLength/(int) state.Length;
            return currentTotalLength;
        }

        private void GetDurations(int currentTotalLength, Duration duration, out int soundDuration, out int pauseDuration)
        {
            switch (duration)
            {
                case Duration.None:
                    soundDuration = 0;
                    pauseDuration = currentTotalLength;
                    return;
                case Duration.Legato:
                    soundDuration = currentTotalLength;
                    pauseDuration = 0;
                    return;
                case Duration.Normal:
                    soundDuration = currentTotalLength*7/8;
                    pauseDuration = currentTotalLength*1/8;
                    return;
                case Duration.Stacatto:
                    soundDuration = currentTotalLength*2/3;
                    pauseDuration = currentTotalLength*1/3;
                    return;
            }
            throw new NotSupportedException(string.Format("Unsupported duration {0}", duration));
        }

        private int StepsToA4( Octave octave, Tone note, Accidental accidental)
        {
            int stepsToOctave4 = (int)octave * 12;
            var stepsToA = (int)note;
            switch (accidental)
            {
                case Accidental.Flat:
                    stepsToA--;
                    break;
                case Accidental.Sharp:
                    stepsToA++;
                    break;
            }
            return stepsToOctave4 + stepsToA;
        }

        protected abstract void PlayPause(int milliseconds);

        protected abstract void PlaySound(int milliseconds, int stepsToA4);
        public abstract void Dispose();
    }
}