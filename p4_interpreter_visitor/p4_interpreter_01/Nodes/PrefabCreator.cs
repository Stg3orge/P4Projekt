using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class PrefabCreator : SyntaxNode
    {
        public PrefabCreator(ParserContext context) : base(context)
        {
        }



        // TODO Add return?
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }


    }
}
