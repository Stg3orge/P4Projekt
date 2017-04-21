using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Type : SyntaxNode
    {
        public string ValueType { get; private set; }

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
            this.ValueType = type;
        }
        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }


        


    }
}
