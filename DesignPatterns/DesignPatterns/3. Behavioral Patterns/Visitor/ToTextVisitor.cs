using System.Collections.Generic;
using System.Globalization;

namespace DesignPatterns.Visitor
{
    public class ToTextVisitor : IVisitor
    {
        private readonly Stack<string> m_TextStack;

        public ToTextVisitor()
        {
            m_TextStack = new Stack<string>();
        }

        public void VisitNumber(Number expression)
        {
            m_TextStack.Push(expression.Value.ToString(CultureInfo.InvariantCulture));
        }

        public void VisitNegation(Negation expression)
        {
            string text = m_TextStack.Pop();
            string result = string.Format("( -{0} )", text);
            m_TextStack.Push(result);
        }

        public void VisitAddition(Addition expression)
        {
            VisitBinary("( {0} + {1} )");
        }

        public void VisitSubstraction(Substraction expression)
        {
            VisitBinary("( {0} - {1} )");
        }

        public void VisitMultiplication(Multiplication expression)
        {
            VisitBinary("{0} * {1}");
        }

        public void VisitDivision(Division expression)
        {
            VisitBinary("{0} / {1}");
        }

        public string GetResult()
        {
            return m_TextStack.Peek();
        }

        private void VisitBinary(string formula)
        {
            string textLeft = m_TextStack.Pop();
            string textRight = m_TextStack.Pop();
            string result = string.Format(formula, textRight, textLeft);
            m_TextStack.Push(result);
        }
    }
}