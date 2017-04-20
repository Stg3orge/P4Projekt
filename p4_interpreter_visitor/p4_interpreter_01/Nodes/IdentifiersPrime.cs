using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class IdentifiersPrime : SyntaxNode
    {
        private IdentifiersPrime identifiersPrime;
        private string v;

        //<IdentifiersPrime> ::= '.' Identifier <IdentifiersPrime>
        public IdentifiersPrime(ParserContext context, string v, IdentifiersPrime identifiersPrime) : base(context)
        {
            this.v = v;
            this.identifiersPrime = identifiersPrime;
        }
    }
}