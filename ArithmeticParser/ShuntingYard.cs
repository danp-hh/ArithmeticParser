using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ArithmeticParser
{
    public class ShuntingYard
    {
        protected virtual string numbers { get; set; }

        protected virtual string operators { get; set; }

        private string lParenthese = @"[\(]";
        private string rParenthese = @"[\)]";
        
        public List<string> Output { get; private set; }
        
        public Stack<Operator> Operators { get; private set; }

        public ShuntingYard()
        {
            numbers = @"[0-9]+";
            operators = @"[+*\-\\]";

            Output = new List<string>();
            Operators = new Stack<Operator>();
        }

        protected virtual string BuildRegex()
        {
            return numbers + "|" + operators + "|" + lParenthese + "|" + rParenthese;
        }

        public string parseExpressionToInfixNotation(string expression)
        {
            string numbersAndOperators = BuildRegex();

            var matches = Regex.Matches(expression, numbersAndOperators);
            
            foreach(Match match in matches)
            {
                if (Regex.IsMatch(match.Value, numbers))
                {
                    AddNumberToOutput(match.Value);
                }
                else if (Regex.IsMatch(match.Value, operators))
                {
                    AddToOperatorStack(match.Value);
                }
                else if (Regex.IsMatch(match.Value, lParenthese))
                {
                    AddLeftParentheseToOperatorStack();
                }
                else if (Regex.IsMatch(match.Value, rParenthese))
                {
                    AddRightParentheseToOperatorStack();
                }
            }

            List<Operator> operatorList = new List<Operator>(Operators.ToArray());
            
            foreach(var item in operatorList)
            {
                Output.Add(item.OperatorSign);
            }

            Operators.Clear();

            string infixNotation = "";
            foreach(var item in Output)
            {
                infixNotation += item;
            }

            return infixNotation;

        }

        protected virtual void AddRightParentheseToOperatorStack()
        {
            while (Operators.Peek().OperatorSign != "(")
            {
                Output.Add(Operators.Pop().OperatorSign);
            }
            Operators.Pop();
        }

        protected virtual void AddLeftParentheseToOperatorStack()
        {
            Operators.Push(new Operator("(", 0));
        }

        protected virtual void AddToOperatorStack(string operatorString)
        {
            Operator opt = ParseOperator(operatorString);

            if (Operators.Count > 0)
            {
                while (Operators.Peek().OperatorSign != "(" && opt.Precedence <= Operators.Peek().Precedence)
                {
                    Output.Add(Operators.Pop().OperatorSign);

                    if (Operators.Count == 0)
                        break;
                }
            }
           

            Operators.Push(opt);
        }

        protected virtual void AddNumberToOutput(string number)
        {
            Output.Add(number);
        }

        protected virtual Operator ParseOperator(string operatorSign)
        {
            if (operatorSign == "+")
                return new Operator("+", 2);

            else if (operatorSign == "-")
                return new Operator("-", 2);

            else if (operatorSign == "*")
                return new Operator("*", 3);

            else if (operatorSign == @"\")
                return new Operator(@"\", 3);

            else
                throw new Exception(String.Format("Could not parse Operator {0}", operatorSign));
        }
    }
}
