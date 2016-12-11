namespace DesignPatterns.Interpreter
{
    public class SetLength : MelodyExpression
    {
        private readonly Length m_Length;

        public SetLength(Length length)
        {
            m_Length = length;
        }

        public override void Execute(Context context)
        {
            context.State.Length = m_Length;
        }
    }
}