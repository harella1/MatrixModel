namespace DesignPatterns.Visitor
{
    public class Multiplication : BinaryOperator
    {
        public Multiplication(AlgebraicExpressions leftOperand, AlgebraicExpressions rightOperand)
            : base(leftOperand, rightOperand)
        {
        }


        protected override void PerformVisit(IVisitor visitor)
        {
            visitor.VisitMultiplication(this);
        }
    }
}