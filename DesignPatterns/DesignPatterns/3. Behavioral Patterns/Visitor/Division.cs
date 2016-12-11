namespace DesignPatterns.Visitor
{
    public class Division : BinaryOperator
    {
        public Division(AlgebraicExpressions leftOperand, AlgebraicExpressions rightOperand)
            : base(leftOperand, rightOperand)
        {
        }

        protected override void PerformVisit(IVisitor visitor)
        {
            visitor.VisitDivision(this);
        }
    }
}