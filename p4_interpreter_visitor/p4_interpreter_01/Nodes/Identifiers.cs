using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Identifiers : SyntaxNode
    {
        private IdentifiersPrime identifiersPrime;
        private string v;
        //<Identifiers> ::= Identifier <IdentifiersPrime>
        public Identifiers(ParserContext context, string v, IdentifiersPrime identifiersPrime) : base(context)
        {
            this.v = v;
            this.identifiersPrime = identifiersPrime;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
