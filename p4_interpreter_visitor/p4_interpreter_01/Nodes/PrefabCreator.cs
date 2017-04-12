using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class PrefabCreator : SyntaxNode
    {
        private string _node1;

        public PrefabCreator(ParserContext context, string node1) : base(context)
        {
            _node1 = node1;
        }



        // TODO Add return?
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }


    }
}
