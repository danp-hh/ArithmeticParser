using NUnit.Framework;
using System.Collections.Generic;

namespace ArithmeticParser.UnitTests
{
    public class BinaryTreeParserTests
    {

        [TestCase("12+", 3)]
        [TestCase("12*", 2)]
        [TestCase("12-", -1)]
        public void ParseInfixNotation_TwoNumbersAndOneOperator_ExpectedValue(string expression, double expectedResult)
        {
            BinaryTreeParser bnt = new BinaryTreeParser();
            double result = bnt.parseInfixNotation(expression);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("123*+", 7)]
        public void ParseInfixNotation_ThreeNumbersAndTwoOperators_ExpectedValue(string expression, double expectedResult)
        {
            BinaryTreeParser bnt = new BinaryTreeParser();
            double result = bnt.parseInfixNotation(expression);

            Assert.AreEqual(expectedResult, result);

        }
    }
}
