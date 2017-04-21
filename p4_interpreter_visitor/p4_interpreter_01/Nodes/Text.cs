using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Text : SyntaxNode
    {
        private TextPrime textPrime;
        private Value value;
        private string v;
        //<Text> ::= <Identifiers> <TextPrime>
        public Text(ParserContext context, Value value, TextPrime textPrime) : base(context)
        {
            this.value = value;
            this.textPrime = textPrime;
        }

        //<Text> ::= StringValue <TextPrime>
        public Text(ParserContext context, string v, TextPrime textPrime) : base(context)
        {
            this.v = v;
            this.textPrime = textPrime;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
