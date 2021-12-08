using System;
using System.Collections.Generic;
using System.Text;

namespace ArithmeticParser
{
    public class ExpressionInterpreter
    {
        public string arithmeticExpression { get; set; }

        public ExpressionInterpreter(string expressionAsText)
        {
            arithmeticExpression = expressionAsText;
        }
        
        public int CalculateWith(Dictionary<Variable, int> variables)
        {
            // insert variables in expression

            string parsedExpression = InsertVariables(variables);

            ShuntingYard sy = new ShuntingYard();
            string infix = sy.parseExpressionToInfixNotation(parsedExpression);

            BinaryTreeParser bnt = new BinaryTreeParser();
            double result = bnt.parseInfixNotation(infix);

            return (int)result;
        }

        public string InsertVariables(Dictionary<Variable, int> variables)
        {
            string parsedExpression = arithmeticExpression;

            foreach(KeyValuePair<Variable, int> kvp in variables)
            {
                if (parsedExpression.Contains(kvp.Key.name))
                {
                    parsedExpression = parsedExpression.Replace(kvp.Key.name.ToString(), kvp.Value.ToString(), StringComparison.InvariantCulture);
                }
            }

            return parsedExpression;

        }

    }
}
