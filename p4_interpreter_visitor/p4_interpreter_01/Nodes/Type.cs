using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Type : SyntaxNode
    {
        private string type;
        private PrefabClasses prefabClasses;

        public string NodeType { get; private set; }

        //<Type> ::= Integer
        //<Type> ::= Decimal
        //<Type> ::= String
        //<Type> ::= Boolean
        //<Type> ::= Point
        public Type(ParserContext context, string type) : base(context)
        {
            this.type = type;
            NodeType = " ";   // TODO:
        }

        //<Type> ::= <PrefabClasses>   
        public Type(ParserContext context, PrefabClasses prefabClasses) : base(context)
        {
            this.prefabClasses = prefabClasses;
            NodeType = " ";   // TODO:
        }


        

    }
}
