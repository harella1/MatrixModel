using System.Collections.Generic;

namespace DesignPatterns.Interpreter
{
    public class Melody : CompoundMelodyExpression
    {
        public Melody(IEnumerable<MelodyExpression> children)
            : base(children)
        {
        }

        protected override void SelfExecute(Context context)
        {
        }
    }
}