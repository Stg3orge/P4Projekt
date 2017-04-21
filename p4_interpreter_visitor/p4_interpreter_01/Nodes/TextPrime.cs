using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class TextPrime : SyntaxNode
    {
        private Identifiers identifiers;
        private TextPrime textPrime;
        private string v;
        //<TextPrime> ::= '+' StringValue <TextPrime>
        public TextPrime(ParserContext context, string v, TextPrime textPrime) : base(context)
        {
            this.v = v;
            this.textPrime = textPrime;
        }

        //<TextPrime> ::= '+' <Identifiers> <TextPrime>
        public TextPrime(ParserContext context, Identifiers identifiers, TextPrime textPrime) : base(context)
        {
            this.identifiers = identifiers;
            this.textPrime = textPrime;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
