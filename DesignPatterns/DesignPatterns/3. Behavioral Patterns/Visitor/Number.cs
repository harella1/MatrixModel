namespace DesignPatterns.Visitor
{
    public class Number : AlgebraicExpressions
    {
        public Number(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }

        public override void Accpet(IVisitor visitor)
        {
            visitor.VisitNumber(this);
        }

        protected override void PerformVisit(IVisitor visitor)
        {
            visitor.VisitNumber(this);
        }
    }
}