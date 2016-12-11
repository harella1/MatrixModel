namespace DesignPatterns.Interpreter
{
    public class ContextState
    {
        public ContextState()
        {
            Octave = Octave.O4;
            Duration = Duration.Normal;
            Accidental = Accidental.Natural;
            Length = Length.L4;
            Tempo = 120;
        }

        public int Tempo { get; set; }

        public Octave Octave { get; set; }
        public Tone Note { get; set; }

        public Duration Duration { get; set; }

        public Accidental Accidental { get; set; }

        public Length Length { get; set; }

        public ContextState Clone()
        {
            var original = this;
            return new ContextState
                {
                    Accidental = original.Accidental,
                    Duration = original.Duration,
                    Length = original.Length,
                    Note = original.Note,
                    Octave = original.Octave,
                    Tempo = original.Tempo
                };
        }

    }
}