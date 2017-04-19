namespace p4_interpreter_01
{
    public class DeclarationList : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Declaration { get; private set; }
        public SyntaxNode Declarations { get; private set; }

        public DeclarationList(ParserContext parserContext, SyntaxNode declaration, SyntaxNode declarations)
            : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Declaration = declaration;
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
            if (Declaration != null)
            {
                returnstring = returnstring + " " + Declaration.ToString() + " ";
            }
            if (Declarations != null)
            {
                returnstring = returnstring + " " + Declarations.ToString() + " ";
            }
            return returnstring;
        }
    }
}