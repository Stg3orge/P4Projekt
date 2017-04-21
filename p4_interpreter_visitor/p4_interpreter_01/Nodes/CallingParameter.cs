using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class CallingParameter : SyntaxNode
    {
        public CallingParameter Parameter { get; private set; }
        public Value Value { get; private set; }


        //<CallingParameter> ::= ',' <Value> <CallingParameter>
        public CallingParameter(ParserContext context, Value value, CallingParameter callingParameter) : base(context)
        {
            this.Value = value;
            this.Parameter = callingParameter;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
