using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class CallingParameters : SyntaxNode
    {
        public CallingParameter CallingParameter { get; private set; }
        public Value Value { get; private set; }


        //<CallingParameters> ::= <Value> <CallingParameter>
        public CallingParameters(ParserContext context, Value value, CallingParameter callingParameter) : base(context)
        {
            this.Value = value;
            this.CallingParameter = callingParameter;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
