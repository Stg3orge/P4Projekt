using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class CallingParameter : SyntaxNode
    {
        private CallingParameter callingParameter;
        private Value value;

        //<CallingParameter> ::= ',' <Value> <CallingParameter>
        public CallingParameter(ParserContext context, Value value, CallingParameter callingParameter) : base(context)
        {
            this.value = value;
            this.callingParameter = callingParameter;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
