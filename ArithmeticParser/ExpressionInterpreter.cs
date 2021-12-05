using System;
using System.Collections.Generic;
using System.Text;
using org.mariuszgromada.math.mxparser;

namespace ArithmeticParser
{
    public class ExpressionInterpreter
    {
        string ExpressionAsText;

        public ExpressionInterpreter(string expressionAsText)
        {
            this.ExpressionAsText = expressionAsText;
        }

        public int CalculateWith(Dictionary<Variable, int> valuesOfVariables)
        {
            Expression eh = new Expression(ExpressionAsText);

            List<Argument> args = new List<Argument>();

            foreach(KeyValuePair<Variable, int> kvp in valuesOfVariables)
            {
                args.Add(new Argument(kvp.Key.name.ToString(), kvp.Value));
            }

            eh.addArguments(args.ToArray());

            return (int) eh.calculate();
        }
    }
}
