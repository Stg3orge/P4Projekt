using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class PrefabClasses : SyntaxNode
    {
        private string v;
        //<PrefabClasses> ::= Character
        //<PrefabClasses> ::= Enemy
        //<PrefabClasses> ::= Camera
        //<PrefabClasses> ::= Square
        //<PrefabClasses> ::= Triangle
        //<PrefabClasses> ::= Sprite
        //<PrefabClasses> ::= Text
        //<PrefabClasses> ::= Trigger
        public PrefabClasses(ParserContext context, string v) : base(context)
        {
            this.v = v;
        }
    }
}
