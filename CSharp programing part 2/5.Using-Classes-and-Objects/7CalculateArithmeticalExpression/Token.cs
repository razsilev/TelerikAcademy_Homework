using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7CalculateArithmeticalExpression
{
    public enum TupeToken { Function, Number, Serarator, Operators, WhiteSpace, End}

    public class Token
    {
        public TupeToken Tupe { get; private set; }
        public string Value { get; private set; }

        public Token(TupeToken tupe, string value)
        {
            this.Tupe = tupe;
            this.Value = value;
        }
    }
}
