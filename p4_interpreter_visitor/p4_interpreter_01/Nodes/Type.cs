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

        public string NodeType { get; private set; }

        //<Type> ::= Integer
        //<Type> ::= Decimal
        //<Type> ::= String
        //<Type> ::= Boolean
        //<Type> ::= Point
        //<PrefabClasses> ::= Character
        //<PrefabClasses> ::= Enemy
        //<PrefabClasses> ::= Camera
        //<PrefabClasses> ::= Square
        //<PrefabClasses> ::= Triangle
        //<PrefabClasses> ::= Sprite
        //<PrefabClasses> ::= Text
        //<PrefabClasses> ::= Trigger
        public Type(ParserContext context, string type) : base(context)
        {
            this.type = type;
            NodeType = " ";   // TODO:
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }


    }
}
