using NUnit.Framework;
using System.Collections.Generic;

namespace ArithmeticParser.UnitTests
{
    public class ExpressionInterpreterTests
    {
        [Test]
        public void InsertVariable_SingleVariable_ExpectedValue()
        {
            string expectedExpression = "1*1";
            ExpressionInterpreter exIn = new ExpressionInterpreter("1*x");

            Dictionary<Variable, int> expected = new Dictionary<Variable, int>();
            expected.Add(new Variable('x'), 1);

            string insertedInfix = exIn.InsertVariables(expected);

            CollectionAssert.AreEqual(expectedExpression, insertedInfix);
        }

        [Test]
        public void CalculateWith()
        {
            string expression = "3*x+2-y*(z+1)";
            ExpressionInterpreter exIn = new ExpressionInterpreter(expression);
            var values = new Dictionary<Variable, int>();

            values.Add(new Variable('x'), 1);
            values.Add(new Variable('y'), 2);
            values.Add(new Variable('z'), 3);

            int result = exIn.CalculateWith(values);

            Assert.AreEqual(12, result);
            
        }
    }
}