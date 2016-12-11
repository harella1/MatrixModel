namespace DesignPatterns.Visitor
{
    public abstract class UnaryOperator : AlgebraicExpressions
    {
        protected UnaryOperator(AlgebraicExpressions operand)
        {
            Operand = operand;
        }

        public AlgebraicExpressions Operand { get; private set; }

        public override void Accpet(IVisitor visitor)
        {
            Operand.Accpet(visitor);
            base.Accpet(visitor);
        }
    }
}