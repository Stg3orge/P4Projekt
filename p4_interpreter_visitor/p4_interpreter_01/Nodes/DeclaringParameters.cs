namespace p4_interpreter_01.Nodes
{
    public class DeclaringParameters : SyntaxNode
    {
        private Declaration declaration;
        private DeclaringParameter declaringParameter;
        public Declaration _Declaration { get {return declaration;}}
        public DeclaringParameter _DeclaringParameter { get {return declaringParameter;}}
        //<DeclaringParameters> ::= <Declaration> <DeclaringParameter>
        public DeclaringParameters(ParserContext context, Declaration declaration, DeclaringParameter declaringParameter) : base(context)
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