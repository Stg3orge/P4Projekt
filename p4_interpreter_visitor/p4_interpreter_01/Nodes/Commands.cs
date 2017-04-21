using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Commands : SyntaxNode
    {
        private Commands commands;
        public Commands Commands1 { get {return commands;}}
        public Declaration Declaration { get; private set; }
        public Statement Statement { get; private set; }



        public string NodeType { get; private set; }

        //<Commands> ::= <Declaration> ';' <Commands>
        public Commands(ParserContext context, Declaration declaration, Commands commands) : base(context)
        {
            this.Declaration = declaration;
            this.commands = commands;
            NodeType = " ";   // TODO:
        }
        //<Commands> ::= <Statement> <Commands>
        public Commands(ParserContext context, Statement statement, Commands commands) : base(context)
        {
            this.Statement = statement;
            this.commands = commands;
            NodeType = " ";   // TODO:
        }


        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
