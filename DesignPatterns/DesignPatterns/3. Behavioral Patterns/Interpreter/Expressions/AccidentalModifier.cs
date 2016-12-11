namespace DesignPatterns.Interpreter
{
    public class AccidentalModifier : MelodyExpression
    {
        private readonly Accidental m_Accidental;

        public AccidentalModifier(Accidental accidental)
        {
            m_Accidental = accidental;
        }

        public override void Execute(Context context)
        {
            context.State.Accidental = m_Accidental;
        }
    }
}