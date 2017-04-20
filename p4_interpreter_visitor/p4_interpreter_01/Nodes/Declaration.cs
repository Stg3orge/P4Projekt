using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Declaration : SyntaxNode
    {
        private Type type;
        private string identifier;

        public string NodeType { get; private set; }

        //<Declaration> ::= <Type> Identifier
        public Declaration(ParserContext context, Type type, string identifier) : base(context)
        {
            this.type = type;
            this.identifier = identifier;
            NodeType = " ";   // TODO:
        }







    }
}
