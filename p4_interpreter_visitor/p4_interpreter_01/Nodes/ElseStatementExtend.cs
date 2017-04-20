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

        // Else Extend Statement
        public ElseStatementExtend(ParserContext context, Commands commands) : base(context)
        {
            this.commands = commands;
            NodeType = " ";   // TODO:
        }
    }
}
