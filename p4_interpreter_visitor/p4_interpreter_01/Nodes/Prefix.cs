﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Prefix : SyntaxNode
    {
        public string PrefixSymbol { get; private set; }

        //<Prefix> ::= '-'
        public Prefix(ParserContext context, string v) : base(context)
        {
            this.PrefixSymbol = v;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
