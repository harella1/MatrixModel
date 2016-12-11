namespace DesignPatterns.Interpreter
{
    internal class Shortener : MelodyExpression
    {
        public override void Execute(Context context)
        {
            context.State.Duration = Duration.Stacatto;
        }
    }
}