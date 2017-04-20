using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class MethodType : SyntaxNode
    {
        private PrefabClasses prefabClasses;
        private string v;
        //<Methodtype> ::= Integer
        //<Methodtype> ::= Decimal
        //<Methodtype> ::= String
        //<Methodtype> ::= Boolean
        //<Methodtype> ::= Point
        //<Methodtype> ::= void
        public MethodType(ParserContext context, string v) : base(context)
        {
            this.v = v;
        }
        //<Methodtype> ::= <PrefabClasses>   
        public MethodType(ParserContext context, PrefabClasses prefabClasses) : base(context)
        {
            this.prefabClasses = prefabClasses;
        }
    }
}
