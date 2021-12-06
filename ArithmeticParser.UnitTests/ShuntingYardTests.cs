using NUnit.Framework;
using System.Collections.Generic;

namespace ArithmeticParser.UnitTests
{
    public class ShuntingYardTests
    {

        private ShuntingYard FactoryAndParse(string expression)
        {
            ShuntingYard sy = new ShuntingYard();
            sy.parseExpression(expression);

            return sy;
        }

        [TestCase("1")]
        [TestCase("10")]
        public void ParseString_SingleNumber_AddedToOutput(string number)
        {
            ShuntingYard sy = FactoryAndParse(number);
            Assert.AreEqual(sy.Output, new List<string>() { number }); 
        }

        [TestCase("+")]
        [TestCase("*")]
        [TestCase("-")]
        [TestCase("/")]
        public void ParseString_SingleOperator_AddedToOperators(string opt)
        {
            ShuntingYard sy = FactoryAndParse(opt);
            Assert.AreEqual(sy.Operators, new List<string>() { opt });
        }

        [TestCase("1", "2", "+")]
        [TestCase("10", "10", "*")]
        public void ParseString_SingleOperatorAndTwoNumber_AddedToCorrectLists(string number1, string number2, string opt)
        {
            ShuntingYard sy = FactoryAndParse(number1 + opt + number2);
            Assert.AreEqual(sy.Operators, new List<string>() { opt });
            Assert.AreEqual(sy.Output, new List<string>() { number1, number2 });

        }


    }
}
