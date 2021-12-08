using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ArithmeticParser
{
    public class BinaryTreeParser
    {
        protected virtual string numberRegex { get; set; }

        protected virtual string operatorRegex { get; set; }

        private Stack<string> matchStack { get; set; }

        public BinaryTreeParser() 
        {
            numberRegex = @"[0-9]";
            operatorRegex = @"[+*\-\\]";
        }

        protected virtual string CreateRegEx()
        {
            return numberRegex + "|" + operatorRegex;
        }

        private Queue<string> addMatchesToStack(string expression, string pattern)
        {
            var matches = Regex.Matches(expression, pattern);

            Queue<string> matchStack = new Queue<string>();
            foreach (Match match in matches)
            {
                matchStack.Enqueue(match.Value);
            }

            return matchStack;
        }

        public double parseInfixNotation(string infixExpression)
        {
            string pattern = CreateRegEx();

            Queue<string> matches = addMatchesToStack(infixExpression, pattern);

            Stack<string> currentNumbers = new Stack<string>();
            Queue<string> currentOperators = new Queue<string>();

            while (Regex.IsMatch(matches.Peek(), numberRegex))
            {
                currentNumbers.Push(matches.Dequeue());
            }

            while (Regex.IsMatch(matches.Peek(), operatorRegex))
            {
                currentOperators.Enqueue(matches.Dequeue());
                if (matches.Count == 0)
                {
                    break;
                }
            }

            double result = 0;

            while(true)
            {
                double number1 = Double.Parse(currentNumbers.Pop());
                double number2 = Double.Parse(currentNumbers.Pop());

                result = ParseExpression(number2, number1, currentOperators.Dequeue());

                if (currentNumbers.Count > 0)
                {
                    currentNumbers.Push(result.ToString());
                }
                else
                {
                    break;
                }

            }

            return result;

            /*
            for(int i = 0; i < matches.Count; i++)
            {
                if(Regex.IsMatch(matches[i].Value, numbers))
                {

                }
            }*/

        }

        protected virtual double ParseExpression(double number1, double number2, string opera)
        {
            if (opera == "+")
            {
                return number1 + number2;
            }
            else if (opera == "-")
            {
                return number1 - number2;
            }
            else if (opera == "*")
            {
                return number1 * number2;
            }
            else if (opera == @"\")
            {
                return number1 / number1;
            }
            else
            {
                throw new Exception(String.Format("Can't parse operator {0}", opera));
            }

        }
    }
}
