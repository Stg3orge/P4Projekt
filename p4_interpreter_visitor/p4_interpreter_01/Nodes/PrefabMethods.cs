using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class PrefabMethods : SyntaxNode
    {
        private string v;
        //<PrefabMethods> ::= Move
        //<PrefabMethods> ::= Delete
        public PrefabMethods(ParserContext context, string v) : base(context)
        {
            this.v = v;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}