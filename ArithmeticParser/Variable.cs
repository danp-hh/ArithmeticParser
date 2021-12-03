using System;
using System.Collections.Generic;
using System.Text;

namespace ArithmeticParser
{
    public class Variable
    {
        public char name{ get; private set; }

        public Variable(char name)
        {
            this.name = name;
        }

        public override int GetHashCode()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Variable);
        }

        public bool Equals(Variable obj)
        {
            return obj != null && obj.name == this.name;
        }
    }
}
