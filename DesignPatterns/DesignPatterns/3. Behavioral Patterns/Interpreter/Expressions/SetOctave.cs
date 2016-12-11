namespace DesignPatterns.Interpreter
{
    public class SetOctave : MelodyExpression
    {
        private readonly Octave m_Octave;

        public SetOctave(Octave octave)
        {
            m_Octave = octave;
        }

        public override void Execute(Context context)
        {
            context.State.Octave = m_Octave;
        }
    }
}