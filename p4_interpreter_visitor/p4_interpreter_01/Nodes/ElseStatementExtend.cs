using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class ElseStatementExtend : SyntaxNode
    {
        private Commands commands;

        public string NodeType { get; private set; }

        //<ElseStatementExtend> ::= else <Commands>
        public ElseStatementExtend(ParserContext context, Commands commands) : base(context)
        {
            this.commands = commands;
            NodeType = " ";   // TODO:
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
