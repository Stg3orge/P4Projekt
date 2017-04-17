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

        public override string ToString()
        {
            string returnstring = "";
            if (_node1 != null)
            {
                returnstring = returnstring + " " + _node1.ToString() + " ";
            }
            return returnstring;
        }

        // TODO Add return?
        public new void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }


    }
}
