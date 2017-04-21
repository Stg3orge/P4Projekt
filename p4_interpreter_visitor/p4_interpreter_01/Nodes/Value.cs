﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Value : SyntaxNode
    {
        public IdentifiersPrime IdentifiersPrime { get; private set; }
        public Prefix Prefix1 { get; private set; }
        public Prefix Prefix2 { get; private set; }
        public string Token1 { get; private set; }
        public string Token2 { get; private set; }


        public string NodeType { get; private set; }

        //<ValueKeywords> ::= Time
        //<Value> ::= StringValue
        //<BooleanValue> ::= false
        //<BooleanValue> ::= true
        public Value(ParserContext context, string v) : base(context)
        {
            this.Token1 = v;
            NodeType = " "; // TODO:!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
        //<Identifiers> ::= Identifier <IdentifiersPrime>
        public Value(ParserContext context, string v, IdentifiersPrime identifiersPrime) : base(context)
        {
            Token1 = v;
            this.IdentifiersPrime = identifiersPrime;
            NodeType = "<Identifiers> ::= Identifier <IdentifiersPrime>";
        }

        //<Value> ::= <Prefix> IntegerValue
        //<Value> ::= <Prefix> DecimalValue
        public Value(ParserContext context, Prefix prefix, string v) : base(context)
        {
            this.Prefix1 = prefix;
            this.Token1 = v;
            NodeType = " "; // TODO:!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
        //<Value> ::= '(' <Prefix> DecimalValue ',' <Prefix> DecimalValue ')'
        public Value(ParserContext context, Prefix prefix1, string v1, Prefix prefix2, string v2) : base(context)
        {
            this.Prefix1 = prefix1;
            this.Token1 = v1;
            this.Prefix2 = prefix2;
            this.Token2 = v2;
            NodeType = "<Value> ::= '(' <Prefix> DecimalValue ',' <Prefix> DecimalValue ')'";
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
