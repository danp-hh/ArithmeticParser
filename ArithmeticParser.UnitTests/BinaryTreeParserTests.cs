using NUnit.Framework;
using System.Collections.Generic;

namespace ArithmeticParser.UnitTests
{
    public class BinaryTreeParserTests
    {
        [Test]
        public void ParseInfixNotationList_OnePlusTow_Three()
        {
            BinaryTreeParser bnt = new BinaryTreeParser();
            double result = bnt.parseInfixNotation(new List<string>() { "1", "2", "+" });

            Assert.AreEqual(3, result);
        }

        [Test]
        public void ParseInfixNotation_ThreeNumbersAndTwoOperators_ExpectedValue()
        {
            BinaryTreeParser bnt = new BinaryTreeParser();
            double result = bnt.parseInfixNotation( new List<string>() { "1", "2", "3", "*", "+", "4", "-" });

            Assert.AreEqual(3, result);

        }

    }
}
