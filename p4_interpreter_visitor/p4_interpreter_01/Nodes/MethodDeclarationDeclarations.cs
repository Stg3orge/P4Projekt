namespace p4_interpreter_01
{
    public class MethodDeclarationDeclarations : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode MethodDeclaration { get; private set; }
        public SyntaxNode Declarations { get; private set; }

        public MethodDeclarationDeclarations(ParserContext parserContext, SyntaxNode methodDeclaration, SyntaxNode declarations)
            : base(parserContext)
        {
            this.parserContext = parserContext;
            this.MethodDeclaration = methodDeclaration;
            this.Declarations = declarations;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (MethodDeclaration != null)
            {
                returnstring = returnstring + " " + MethodDeclaration.ToString() + " ";
            }
            if (Declarations != null)
            {
                returnstring = returnstring + " " + Declarations.ToString() + " ";
            }
            return returnstring;
        }
    }
}