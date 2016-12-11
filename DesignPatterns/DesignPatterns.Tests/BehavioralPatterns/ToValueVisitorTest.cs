using DesignPatterns.Visitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Tests.BehavioralPatterns
{
    [TestClass]
    public class ToValueVisitorTest
    {
        [TestMethod]
        public void Simple_Addition()
        {
            const int expected = (3 + 5);

            var expression =
                new Addition(
                    new Number(3),
                    new Number(5));

            AssertExpression(expression, expected);
        }

        [TestMethod]
        public void Simple_Division()
        {
            const int expected = (6 / 2);

            var expression =
                new Division(
                    new Number(6),
                    new Number(2));

            AssertExpression(expression, expected);
        }

        [TestMethod]
        public void Simple_Substraction()
        {
            const int expected = (6 - 2);

            var expression =
                new Substraction(
                    new Number(6),
                    new Number(2));

            AssertExpression(expression, expected);
        }

        [TestMethod]
        public void Triple_Addition()
        {
            const int expected = ( 1 + (3 + 5));

            var expression =
                new Addition(
                    new Number(1),
                    new Addition(
                        new Number(3),
                        new Number(5)));

            AssertExpression(expression, expected);
        }

        [TestMethod]
        public void Addition_And_Multiplication()
        {
            const int expected = (1 + (3 * 5));

            var expression =
                new Addition(
                    new Number(1),
                    new Multiplication(
                        new Number(3),
                        new Number(5)));

            AssertExpression(expression, expected);
        }

        [TestMethod]
        public void Negation()
        {
            const int expected = (-3);

            var expression =
                new Negation(
                    new Number(3));

            AssertExpression(expression, expected);
        }

        [TestMethod]
        public void Complex_Expression()
        {
            const int expected = ((3 + 5*6/2) - 8);

            var expression =
                new Substraction(
                    new Addition(
                        new Number(3),
                        new Multiplication(
                            new Number(5),
                            new Division(
                                new Number(6),
                                new Number(2)))),
                    new Number(8));

            AssertExpression(expression, expected);
        }

        private static void AssertExpression(AlgebraicExpressions expression, int expected)
        {
            var visitor = new ToValueVisitor();
            expression.Accpet(visitor);
            int actual = visitor.GetResult();
            Assert.AreEqual(expected, actual);
        }
    }
}