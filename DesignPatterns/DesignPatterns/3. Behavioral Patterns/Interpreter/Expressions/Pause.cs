namespace DesignPatterns.Interpreter
{
    public class Pause : CompoundMelodyExpression
    {
        public Pause(MelodyExpression lenngth) 
            : base(lenngth)
        {
                
        }
        protected override void SelfExecute(Context context)
        {
            context.SaveState();
            base.Execute(context);
            context.State.Duration = Duration.None;
            context.Play();
            context.RestoreState();
        }
    }
}