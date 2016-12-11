using System.Collections.Generic;

namespace DesignPatterns.Interpreter
{
    public abstract class CompoundMelodyExpression : MelodyExpression
        {
            private readonly IEnumerable<MelodyExpression> m_Children;

            protected CompoundMelodyExpression(IEnumerable<MelodyExpression> children)
            {
                m_Children = children;
            }

            protected CompoundMelodyExpression(params MelodyExpression[] children)
            {
                m_Children = children;
            }

            public override void Execute(Context context)
            {
                foreach (MelodyExpression melodyExpression in m_Children)
                {
                    melodyExpression.Execute(context);
                }
                SelfExecute(context);
            }

            protected abstract void SelfExecute(Context context);
        }
}