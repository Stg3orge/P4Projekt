using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class ElseIfStatementExtend : SyntaxNode
    {
        private BooleanExpression booleanExpression;
        private Commands commands;
        private ElseIfStatementExtend elseIfStatementExtend;
        private ElseStatementExtend elseStatementExtend;

        public string NodeType { get; private set; }

        //<ElseIfStatementExtend> ::= 'else if' '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend>
        public ElseIfStatementExtend(ParserContext context, ElseStatementExtend elseStatementExtend) : base(context)
        {
            this.elseStatementExtend = elseStatementExtend;
            NodeType = " ";   // TODO:
        }

        //<ElseIfStatementExtend> ::= <ElseStatementExtend>
        public ElseIfStatementExtend(ParserContext context, BooleanExpression booleanExpression, Commands commands, ElseIfStatementExtend elseIfStatementExtend) : base(context)
        {
            this.booleanExpression = booleanExpression;
            this.commands = commands;
            this.elseIfStatementExtend = elseIfStatementExtend;
            NodeType = " ";   // TODO:
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
