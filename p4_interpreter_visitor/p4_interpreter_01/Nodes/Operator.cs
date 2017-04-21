using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Operator : SyntaxNode
    {
        public string MathOperatorType  { get; private set; }

        //<operator> ::= '*'
        //<operator> ::= '+'
        //<operator> ::= '/'
        //<operator> ::= '-'
        public Operator(ParserContext context, string mathOperator) : base(context)
        {
            this.MathOperatorType = mathOperator;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
