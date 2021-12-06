using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ArithmeticParser
{
    public class ShuntingYard
    {
        private string numbers = @"[0-9]+";
        private string operators = @"[+*\/\^\-\(\)]";

        public Stack<string> Output { get; private set; }
        
        public Stack<string> Operators { get; private set; }

        public ShuntingYard()
        {
            Output = new Stack<string>();
            Operators = new Stack<string>();
        }

        public void parseExpression(string expression)
        {
            string numbersAndOperators = numbers + "|" + operators;
            var matches = Regex.Matches(expression, numbersAndOperators);
            
            foreach(Match match in matches)
            {
                if(Regex.IsMatch(match.Value, numbers))
                {
                    Output.Push(match.Value);
                }
                else
                {
                    // here is some magic necessary
                    Operators.Push(match.Value);
                }
            }


        }
    }
}
