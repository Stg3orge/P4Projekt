using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Commands : SyntaxNode
    {
        public Commands Commands1 { get; private set; }
        public Declaration Declaration { get; private set; }
        public Statement Statement { get; private set; }

        public NodeTypes NodeType { get; private set; }

        public enum NodeTypes
        {
            DeclarationCommands, StatementCommands
        }

        //<Commands> ::= <Declaration> ';' <Commands>
        public Commands(ParserContext context, Declaration declaration, Commands commands) : base(context)
        {
            this.Declaration = declaration;
            this.Commands1 = commands;
            NodeType = NodeTypes.DeclarationCommands;
        }
        //<Commands> ::= <Statement> <Commands>
        public Commands(ParserContext context, Statement statement, Commands commands) : base(context)
        {
            this.Statement = statement;
            this.Commands1 = commands;
            NodeType = NodeTypes.StatementCommands;
        }


        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
