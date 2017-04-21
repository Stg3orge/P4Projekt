using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class ElseStatementExtend : SyntaxNode
    {
        public Commands Commands { get; private set; }

        //<ElseStatementExtend> ::= else <Commands>
        public ElseStatementExtend(ParserContext context, Commands commands) : base(context)
        {
            this.Commands = commands;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
