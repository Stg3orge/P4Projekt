using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class BooleanValue : SyntaxNode
    {
        private string v;
        //<BooleanValue> ::= true
        //<BooleanValue> ::= false
        public BooleanValue(ParserContext context, string v) : base(context)
        {
            this.v = v;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
