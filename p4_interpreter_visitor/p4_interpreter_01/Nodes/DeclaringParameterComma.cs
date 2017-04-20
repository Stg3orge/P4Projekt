namespace p4_interpreter_01
{
    public class DeclaringParameterComma : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Declaration { get; private set; }
        public SyntaxNode DeclaringParameter { get; private set; }

        public DeclaringParameterComma(ParserContext parserContext, SyntaxNode declaration, SyntaxNode declaringParameter)
            : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Declaration = declaration;
            this.DeclaringParameter = declaringParameter;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (Declaration != null)
            {
                returnstring = returnstring + " " + Declaration.ToString() + " ";
            }
            if (DeclaringParameter != null)
            {
                returnstring = returnstring + " " + DeclaringParameter.ToString() + " ";
            }
            return returnstring;
        }
    }
}