using System;
using System.Collections.Generic;
using System.Text;

namespace ArithmeticParser
{
    public class ExpressionInterpreter
    {
        public Dictionary<Variable, int> _variableList = new Dictionary<Variable, int>();

        public Dictionary<Variable, int> VariableList
        {
            get
            {
                return _variableList;
            }
        }

        public ExpressionInterpreter(string expressionAsText)
        {
            // VariableParser vp = new VariableParser(expressionAsText);
            _variableList.Add(new Variable('x'), 1);

        }
    }
}
