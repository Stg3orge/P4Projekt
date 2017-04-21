using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class DeclaringParameter : SyntaxNode
    {
        private Declaration declaration;
        private DeclaringParameter declaringParameter;
        public Declaration _Declaration { get { return _Declaration; }}
        public DeclaringParameter Parameter { get {return declaringParameter;}}

        //<DeclaringParameter> ::= ',' <Declaration> <DeclaringParameter>
        public DeclaringParameter(ParserContext context, Declaration declaration, DeclaringParameter declaringParameter) : base(context)
        {
            this.declaration = declaration;
            this.declaringParameter = declaringParameter;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
