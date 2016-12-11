using System;
using DesignPatterns.Visitor;

namespace DesignPatterns
{
    public partial class Program
    {
        public static void Visitor()
        {
            //"( ( 3 + 5 * 2 / 6 ) - 8 )"
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
            var visitor = new ToTextVisitor();
            expression.Accpet(visitor);
            string expressionText = visitor.GetResult();

            Console.WriteLine(expressionText);
        }
    }
}