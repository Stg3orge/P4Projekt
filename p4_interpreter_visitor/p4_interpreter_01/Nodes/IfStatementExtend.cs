using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class IfStatementExtend : SyntaxNode
    {
        public BooleanExpression BooleanExpression { get; private set; }
        public Commands Commands { get; private set; }
        public IfStatementExtend StatementExtend { get; private set; }

        public NodeTypes NodeType { get; private set; }

        public enum NodeTypes
        {
            ElseIfStatement, ElseStatement
        }

        //<ElseIfStatementExtend> ::= 'else if' '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend>
        public IfStatementExtend(ParserContext context, BooleanExpression booleanExpression, Commands commands, IfStatementExtend ifStatementExtend) : base(context)
        {
            this.BooleanExpression = booleanExpression;
            this.Commands = commands;
            this.StatementExtend = ifStatementExtend;
            NodeType = NodeTypes.ElseIfStatement;
        }

        //<ElseStatementExtend> ::= else <Commands>
        public IfStatementExtend(ParserContext context, Commands commands) : base(context)
        {
            this.Commands = commands;
            NodeType = NodeTypes.ElseStatement;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }

    }
}
