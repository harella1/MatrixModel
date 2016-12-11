using System;
using System.Collections.Generic;

namespace DesignPatterns.Visitor
{
    public class ToValueVisitor : IVisitor
    {
        private readonly Stack<int> m_OperandStack;

        public ToValueVisitor()
        {
            m_OperandStack = new Stack<int>();
        }

        public void VisitNumber(Number expression)
        {
            m_OperandStack.Push(expression.Value);
        }

        public void VisitNegation(Negation expression)
        {
            int operand = m_OperandStack.Pop();
            int result = -operand;
            m_OperandStack.Push(result);
        }

        public void VisitAddition(Addition expression)
        {
            VisitBinary(
                (left, right) => left + right);
        }

        public void VisitSubstraction(Substraction expression)
        {
            VisitBinary(
                (left, right) => left - right);
        }

        public void VisitMultiplication(Multiplication expression)
        {
            VisitBinary(
                (left, right) => left*right);
        }

        public void VisitDivision(Division expression)
        {
            VisitBinary(
                (left, right) => left/right);
        }

        private void VisitBinary(Func<int, int, int> operation)
        {
            int rightOperand = m_OperandStack.Pop();
            int leftOperand = m_OperandStack.Pop();
            int result = operation(leftOperand, rightOperand);
            m_OperandStack.Push(result);
        }

        public int GetResult()
        {
            return m_OperandStack.Peek();
        }
    }
}