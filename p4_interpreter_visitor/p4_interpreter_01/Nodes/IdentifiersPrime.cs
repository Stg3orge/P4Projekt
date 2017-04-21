using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class IdentifiersPrime : SyntaxNode
    {
        public IdentifiersPrime Prime { get; private set; }
        public string Identifier { get; private set; }

        //<IdentifiersPrime> ::= '.' Identifier <IdentifiersPrime>
        public IdentifiersPrime(ParserContext context, string v, IdentifiersPrime identifiersPrime) : base(context)
        {
            this.Identifier = v;
            this.Prime = identifiersPrime;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}