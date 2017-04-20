using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Text : SyntaxNode
    {
        private Identifiers identifiers;
        private TextPrime textPrime;
        private string v;
        //<Text> ::= <Identifiers> <TextPrime>
        public Text(ParserContext context, Identifiers identifiers, TextPrime textPrime) : base(context)
        {
            this.identifiers = identifiers;
            this.textPrime = textPrime;
        }

        //<Text> ::= StringValue <TextPrime>
        public Text(ParserContext context, string v, TextPrime textPrime) : base(context)
        {
            this.v = v;
            this.textPrime = textPrime;
        }
    }
}
