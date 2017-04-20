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
        private Declaration declaration;
        private Statement statement;
        //<Commands> ::= <Declaration> ';' <Commands>
        public Commands(ParserContext context, Declaration declaration, Commands commands) : base(context)
        {
            this.declaration = declaration;
            this.commands = commands;
        }
        //<Commands> ::= <Statement> <Commands>
        public Commands(ParserContext context, Statement statement, Commands commands) : base(context)
        {
            this.statement = statement;
            this.commands = commands;
        }
    }
}
