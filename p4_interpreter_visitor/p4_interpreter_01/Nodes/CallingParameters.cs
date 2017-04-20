using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class CallingParameters : SyntaxNode
    {
        private CallingParameter callingParameter;
        private Value value;

        //<CallingParameters> ::= <Value> <CallingParameter>
        public CallingParameters(ParserContext context, Value value, CallingParameter callingParameter) : base(context)
        {
            this.value = value;
            this.callingParameter = callingParameter;
        }
    }
}
