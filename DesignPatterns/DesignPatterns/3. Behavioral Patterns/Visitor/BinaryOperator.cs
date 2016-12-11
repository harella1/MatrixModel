namespace DesignPatterns.Visitor
{
    public abstract class BinaryOperator : AlgebraicExpressions
    {
        protected BinaryOperator(AlgebraicExpressions leftOperand, AlgebraicExpressions rightOperand)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
        }

        public AlgebraicExpressions LeftOperand { get; private set; }
        public AlgebraicExpressions RightOperand { get; private set; }

        public override void Accpet(IVisitor visitor)
        {
            LeftOperand.Accpet(visitor);
            RightOperand.Accpet(visitor);
            base.Accpet(visitor);
        }
    }
}