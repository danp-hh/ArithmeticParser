using NUnit.Framework;
using System.Collections.Generic;

namespace ArithmeticParser.UnitTests
{
    public class Tests
    {
        [TestCase('x', 1)]
        [TestCase('x', 2)]
        public void ParseExpression_SingleVariable_AddedToVariableList(char varName, int varValue)
        {
            ExpressionInterpreter ei = new ExpressionInterpreter("1x");

            Dictionary<Variable, int> expected = new Dictionary<Variable, int>();
            expected.Add(new Variable(varName), varValue);

            CollectionAssert.AreEqual(expected, ei._variableList);
        }
    }
}