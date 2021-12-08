using System;
using System.Collections.Generic;
using System.Text;

namespace ArithmeticParser
{
    public class Operator
    {
        public int Precedence { get; private set; }

        public string OperatorSign { get; private set; }

        public Operator(string operatorSign, int precedence)
        {
            OperatorSign = operatorSign;
            Precedence = precedence;

        }

    }
}
