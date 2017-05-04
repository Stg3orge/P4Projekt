using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Text : SyntaxNode
    {
        public TextPrime TextPrime { get; private set; }
        public Value Value { get; private set; }
        public string StringValue { get; private set; }

        public NodeTypes NodeType { get; private set; }

        public enum NodeTypes
        {
            IdentifiersTextPrime, StringValueTextPrime
        }

        //<Text> ::= <Identifiers> <TextPrime>
        public Text(ParserContext context, Value value, TextPrime textPrime) : base(context)
        {
            this.Value = value;
            this.TextPrime = textPrime;
            NodeType = NodeTypes.IdentifiersTextPrime;
        }

        //<Text> ::= StringValue <TextPrime>
        public Text(ParserContext context, string v, TextPrime textPrime) : base(context)
        {
            this.StringValue = v;
            this.TextPrime = textPrime;
            NodeType = NodeTypes.StringValueTextPrime;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
