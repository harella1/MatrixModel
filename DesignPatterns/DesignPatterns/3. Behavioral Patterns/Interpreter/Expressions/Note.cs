namespace DesignPatterns.Interpreter
{
    public class Note : CompoundMelodyExpression
    {
        private readonly Tone m_Tone;

        public Note(Tone tone, params MelodyExpression[] children)
            : base(children)
        {
            m_Tone = tone;
        }

        public override void Execute(Context context)
        {
            context.SaveState();
            base.Execute(context);
            context.RestoreState();
        }

        protected override void SelfExecute(Context context)
        {
            context.State.Note = m_Tone;
            context.Play();
        }
    }
}