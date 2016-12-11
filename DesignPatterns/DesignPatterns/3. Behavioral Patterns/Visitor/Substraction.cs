namespace DesignPatterns.Visitor
{
    public class Substraction : BinaryOperator
    {
        public Substraction(AlgebraicExpressions leftOperand, AlgebraicExpressions rightOperand)
            : base(leftOperand, rightOperand)
        {
        }

        protected override void PerformVisit(IVisitor visitor)
        {
            visitor.VisitSubstraction(this);
        }
    }
}