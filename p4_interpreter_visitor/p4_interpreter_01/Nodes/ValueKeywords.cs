using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class ValueKeywords : SyntaxNode
    {
        private string v;
        //<ValueKeywords> ::= Time
        public ValueKeywords(ParserContext context, string v) : base(context)
        {
            this.v = v;
        }
    }
}
