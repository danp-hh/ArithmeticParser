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

        public double parseInfixNotation(List<string> infixExpressionList)
        {
            string pattern = CreateRegEx();

            Queue<string> expressionQueue = new Queue<string>(infixExpressionList);

            Stack<string> currentNumbers = new Stack<string>();
            Queue<string> currentOperators = new Queue<string>();

            double result = 0;

            while (true)
            {
                while (Regex.IsMatch(expressionQueue.Peek(), numberRegex))
                {
                    currentNumbers.Push(expressionQueue.Dequeue());
                }

                while (Regex.IsMatch(expressionQueue.Peek(), operatorRegex))
                {
                    currentOperators.Enqueue(expressionQueue.Dequeue());
                    if (expressionQueue.Count == 0)
                    {
                        break;
                    }
                }

                while(currentNumbers.Count > 1)
                {
                    double number1 = Double.Parse(currentNumbers.Pop());
                    double number2 = Double.Parse(currentNumbers.Pop());

                    result = ParseExpression(number2, number1, currentOperators.Dequeue());

                    currentNumbers.Push(result.ToString());
                }

                if (expressionQueue.Count == 0)
                {
                    break;
                }
                
            }

            return result;

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
