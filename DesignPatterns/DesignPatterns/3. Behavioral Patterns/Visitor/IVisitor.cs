namespace DesignPatterns.Visitor
{
    public interface IVisitor
    {
        void VisitNumber(Number expression);
        void VisitNegation(Negation expression);
        void VisitAddition(Addition expression);
        void VisitSubstraction(Substraction expression);
        void VisitMultiplication(Multiplication expression);
        void VisitDivision(Division expression);
    }
}