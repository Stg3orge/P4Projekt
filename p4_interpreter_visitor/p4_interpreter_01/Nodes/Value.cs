using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Value : SyntaxNode
    {
        private BooleanValue booleanValue;
        private Identifiers identifiers;
        private Prefix prefix;
        private Prefix prefix1;
        private string v;
        private string v1;
        private ValueKeywords valueKeywords;

        //<Value> ::= StringValue
        public Value(ParserContext context, string v) : base(context)
        {
            this.v = v;
        }
        //<Value> ::= <ValueKeywords>
        public Value(ParserContext context, ValueKeywords valueKeywords) : base(context)
        {
            this.valueKeywords = valueKeywords;
        }

        //<Value> ::= <BooleanValue>   
        public Value(ParserContext context, BooleanValue booleanValue) : base(context)
        {
            this.booleanValue = booleanValue;
        }

        //<Value> ::= <Identifiers>
        public Value(ParserContext context, Identifiers identifiers) : base(context)
        {
            this.identifiers = identifiers;
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
    }
}
