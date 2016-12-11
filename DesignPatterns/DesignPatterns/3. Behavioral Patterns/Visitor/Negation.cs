namespace DesignPatterns.Visitor
{
    public class Negation : UnaryOperator
    {
        public Negation(AlgebraicExpressions operand) : base(operand)
        {
        }

        protected override void PerformVisit(IVisitor visitor)
        {
            visitor.VisitNegation(this);
        }
    }
}