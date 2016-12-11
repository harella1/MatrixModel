namespace DesignPatterns.Visitor
{
    public abstract class AlgebraicExpressions
    {
        public virtual void Accpet(IVisitor visitor)
        {
            PerformVisit(visitor);
        }

        protected abstract void PerformVisit(IVisitor visitor);
    }
}