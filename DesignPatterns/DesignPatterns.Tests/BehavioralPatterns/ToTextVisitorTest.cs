using DesignPatterns.Visitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Tests.BehavioralPatterns
{
    [TestClass]
    public class ToTextVisitorTest
    {
        [TestMethod]
        public void Test_Simple_Addition()
        {
            const string expected = "( 3 + 5 )";

            var expression =
                new Addition(
                    new Number(3),
                    new Number(5));

            AssertExpression(expression, expected);
        }

        [TestMethod]
        public void Test_Negation()
        {
            const string expected = "( -3 )";

            var expression =
                new Negation(
                    new Number(3));

            AssertExpression(expression, expected);
        }

        [TestMethod]
        public void Test_Complex_Expression()
        {
            const string expected = "( ( 3 + 5 * 2 / 6 ) - 8 )";

            var expression =
                new Substraction(
                    new Addition(
                        new Number(3),
                        new Multiplication(
                            new Number(5),
                            new Division(
                                new Number(2),
                                new Number(6)))),
                    new Number(8));

            AssertExpression(expression, expected);
        }

        private static void AssertExpression(AlgebraicExpressions expression, string expected)
        {
            var visitor = new ToTextVisitor();
            expression.Accpet(visitor);
            string actual = visitor.GetResult();
            Assert.AreEqual(expected, actual);
        }
    }
}