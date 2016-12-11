namespace DesignPatterns.Visitor
{
    public class Addition : BinaryOperator
    {
        public Addition(AlgebraicExpressions leftOperand, AlgebraicExpressions rightOperand)
            : base(leftOperand, rightOperand)
        {
        }

        protected override void PerformVisit(IVisitor visitor)
        {
            visitor.VisitAddition(this);
        }
    }
}