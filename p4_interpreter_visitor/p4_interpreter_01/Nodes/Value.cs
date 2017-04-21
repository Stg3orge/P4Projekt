using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Value : SyntaxNode
    {
        private IdentifiersPrime identifiersPrime;
        private Prefix prefix;
        private Prefix prefix1;
        private string v;
        private string v1;
        //<ValueKeywords> ::= Time
        //<Value> ::= StringValue
        //<BooleanValue> ::= false
        //<BooleanValue> ::= true
        public Value(ParserContext context, string v) : base(context)
        {
            this.v = v;
        }
        //<Identifiers> ::= Identifier <IdentifiersPrime>
        public Value(ParserContext context, string v, IdentifiersPrime identifiersPrime) : this(context, v)
        {
            this.identifiersPrime = identifiersPrime;
        }

        //<Value> ::= <Prefix> IntegerValue
        //<Value> ::= <Prefix> DecimalValue
        public Value(ParserContext context, Prefix prefix, string v) : base(context)
        {
            this.prefix = prefix;
            this.v = v;
        }
        //<Value> ::= '(' <Prefix> DecimalValue ',' <Prefix> DecimalValue ')'   
        public Value(ParserContext context, Prefix prefix, string v, Prefix prefix1, string v1) : base(context)
        {
            this.prefix1 = prefix1;
            this.v1 = v1;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
