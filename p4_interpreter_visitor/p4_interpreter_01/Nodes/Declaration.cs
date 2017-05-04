using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Declaration : SyntaxNode
    {
        public string IdentifierNode { get; private set; }
        public Type TypeNode { get; private set; }

        //<Declaration> ::= <Type> Identifier
        public Declaration(ParserContext context, Type type, string identifier) : base(context)
        {
            this.TypeNode = type;
            this.IdentifierNode = identifier;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
