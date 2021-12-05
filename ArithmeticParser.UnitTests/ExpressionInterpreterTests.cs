using NUnit.Framework;
using System.Collections.Generic;
using org.mariuszgromada.math.mxparser;

namespace ArithmeticParser.UnitTests
{
    public class Tests
    {
        [TestCase('x', 1)]
        [TestCase('x', 2)]
        public void ParseExpression_SingleVariableMultiplicationWithOne_ReturnsVariableValue(char varName, int varValue)
        {
            ExpressionInterpreter ei = new ExpressionInterpreter("1*x");
            var values = new Dictionary<Variable, int>();
          
            values.Add(new Variable(varName), varValue);
            int result = ei.CalculateWith(values);

            Assert.AreEqual(result, varValue);
        }
        
        [Test]
        public void ParseExpression_ExpressionWithThreeVariables_ReturnsMinus17()
        {
            var values = new Dictionary<Variable, int>();
            values.Add(new Variable('x'), 1);
            values.Add(new Variable('y'), 2);
            values.Add(new Variable('z'), 3);

            var interpreter = new ExpressionInterpreter("3*x + 20 - y*(z+17)");
            int result = interpreter.CalculateWith(values);

            Assert.AreEqual(result, -17);

        }
    }
}