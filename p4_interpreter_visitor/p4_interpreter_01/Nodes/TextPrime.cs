using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class TextPrime : SyntaxNode
    {
        public TextPrime Prime { get; private set; }
        public Value Value { get; private set; }
        public string StringValue { get; private set; }

        public string NodeType { get; private set; }

        //<TextPrime> ::= '+' StringValue <TextPrime>
        public TextPrime(ParserContext context, string v, TextPrime textPrime) : base(context)
        {
            this.StringValue = v;
            this.Prime = textPrime;
            NodeType = "<TextPrime> ::= '+' StringValue <TextPrime>";
        }

        //<TextPrime> ::= '+' <Identifiers> <TextPrime>
        public TextPrime(ParserContext context, Value value, TextPrime textPrime) : base(context)
        {
            this.Value = value;
            this.Prime = textPrime;
            NodeType = "<TextPrime> ::= '+' <Identifiers> <TextPrime>";
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
