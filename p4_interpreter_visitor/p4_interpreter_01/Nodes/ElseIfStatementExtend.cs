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
        public BooleanExpression BooleanExpression { get; private set; }
        public Commands Commands { get; private set; }
        public ElseIfStatementExtend IfStatementExtend { get; private set; }
        public ElseStatementExtend ElseStatementExtend { get; private set; }


        public string NodeType { get; private set; }

        //<ElseIfStatementExtend> ::= 'else if' '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend>
        public ElseIfStatementExtend(ParserContext context, ElseStatementExtend elseStatementExtend) : base(context)
        {
            this.ElseStatementExtend = elseStatementExtend;
            NodeType = "<ElseIfStatementExtend> ::= 'else if' '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend>";
        }

        //<ElseIfStatementExtend> ::= <ElseStatementExtend>
        public ElseIfStatementExtend(ParserContext context, BooleanExpression booleanExpression, Commands commands, ElseIfStatementExtend elseIfStatementExtend) : base(context)
        {
            this.BooleanExpression = booleanExpression;
            this.Commands = commands;
            this.IfStatementExtend = elseIfStatementExtend;
            NodeType = "<ElseIfStatementExtend> ::= <ElseStatementExtend>"; 
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
