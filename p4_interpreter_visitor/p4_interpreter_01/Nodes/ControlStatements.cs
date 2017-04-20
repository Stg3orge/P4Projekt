using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class ControlStatements : SyntaxNode
    {
        private BooleanExpression booleanExpression;
        private Commands commands;
        private ElseIfStatementExtend elseIfStatementExtend;

        public string NodeType { get; private set; }

        // if Statement
        public ControlStatements(ParserContext context, BooleanExpression booleanExpression, Commands commands) : base(context)
        {
            this.booleanExpression = booleanExpression;
            this.commands = commands;
            NodeType = " ";   // TODO:
        }

        // While Statement
        public ControlStatements(ParserContext context, BooleanExpression booleanExpression, Commands commands, ElseIfStatementExtend elseIfStatementExtend) : base(context)
        {
            this.booleanExpression = booleanExpression;
            this.commands = commands;
            this.elseIfStatementExtend = elseIfStatementExtend;
            NodeType = " ";   // TODO:
        }
    }
}
