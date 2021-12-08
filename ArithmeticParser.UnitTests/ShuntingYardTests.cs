using NUnit.Framework;
using System.Collections.Generic;

namespace ArithmeticParser.UnitTests
{
    public class ShuntingYardTests
    {

        private ShuntingYard FactoryAndParse(string expression)
        {
            ShuntingYard sy = new ShuntingYard();
            sy.parseExpressionToInfixNotation(expression);

            return sy;
        }

        [TestCase("1")]
        [TestCase("10")]
        public void ParseString_SingleNumber_AddedToOutput(string number)
        {
            ShuntingYard sy = FactoryAndParse(number);

            Assert.AreEqual(new List<string>() { number }, sy.Output); 
        }

        [TestCase("+")]
        [TestCase("*")]
        [TestCase("-")]
        [TestCase(@"\")]
        public void ParseString_SingleOperator_AddedToOutput(string opt)
        {
            ShuntingYard sy = FactoryAndParse(opt);

            Assert.AreEqual(new List<string>() { opt }, sy.Output);
        }

        [TestCase("1", "2", "+")]
        [TestCase("10", "20", "*")]
        public void ParseString_SingleOperatorAndTwoNumber_AddedToCorrectLists(string number1, string number2, string opt)
        {
            ShuntingYard sy = FactoryAndParse(number1 + opt + number2);

            List<string> expectedOutput = new List<string>() { number1, number2, opt };

            Assert.AreEqual(expectedOutput, sy.Output);
        }
        
        [Test]
        public void ParseString_ParentheseAndMultiplication_ExpectedOutput()
        {
            ShuntingYard sy = FactoryAndParse("(1+1)*2");

            List<string> expectedOutput = new List<string>() { "1", "1", "+", "2", "*"};

            Assert.AreEqual(expectedOutput, sy.Output);
        }
        
        [Test]
        public void ParseString_Parenthese3NumberAdditionAndMultiplication_ExpectedOutput()
        {
            ShuntingYard sy = FactoryAndParse("(1+1+1)*2");
            List<string> expectedOutput = new List<string>() { "1", "1", "+", "1", "+", "2", "*" };

            Assert.AreEqual(expectedOutput, sy.Output);
        }

        [Test]
        public void ParseString_ParentheseAndMultiplicationAndAddition_ExpcetedOutput()
        {
            ShuntingYard sy = FactoryAndParse("1+2*3-4");

            List<string> expcetedOutput = new List<string>() { "1", "2", "3", "*", "+", "4", "-"};

            Assert.AreEqual(expcetedOutput, sy.Output);
        }

    }
}
