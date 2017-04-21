using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class DeclaringParameter : SyntaxNode
    {
        public Declaration Declaration { get; private set; }
        public DeclaringParameter Parameter { get; private set; }


        //<DeclaringParameter> ::= ',' <Declaration> <DeclaringParameter>
        public DeclaringParameter(ParserContext context, Declaration declaration, DeclaringParameter declaringParameter) : base(context)
        {
            this.Declaration = declaration;
            this.Parameter = declaringParameter;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
