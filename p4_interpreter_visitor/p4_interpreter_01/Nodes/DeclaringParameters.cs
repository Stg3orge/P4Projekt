namespace p4_interpreter_01.Nodes
{
    public class DeclaringParameters : SyntaxNode
    {
        public Declaration Declaration { get; private set; }
        public DeclaringParameter DeclaringParameter { get; private set; }



        //<DeclaringParameters> ::= <Declaration> <DeclaringParameter>
        public DeclaringParameters(ParserContext context, Declaration declaration, DeclaringParameter declaringParameter) : base(context)
        {
            this.Declaration = declaration;
            this.DeclaringParameter = declaringParameter;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}