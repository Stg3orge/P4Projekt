using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class PrefabCreator : SyntaxNode
    {
        public string PrefabClassToken { get; private set; }

        public PrefabCreator(ParserContext context, string prefabClassToken) : base(context)
        {
            PrefabClassToken = prefabClassToken;
            Nodes.Add(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (PrefabClassToken != null)
            {
                returnstring = returnstring + " " + PrefabClassToken.ToString() + " ";
            }
            return returnstring;
        }

        // TODO Add return?
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}