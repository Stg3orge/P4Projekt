namespace p4_interpreter_01
{
    public class TextPrimeIdentifiers : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode syntaxNode1 { get; private set; }
        public SyntaxNode syntaxNode2 { get; private set; }

        public TextPrimeIdentifiers(ParserContext parserContext, SyntaxNode syntaxNode1, SyntaxNode syntaxNode2)
            : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode1 = syntaxNode1;
            this.syntaxNode2 = syntaxNode2;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (syntaxNode1 != null)
            {
                returnstring = returnstring + " " + syntaxNode1.ToString() + " ";
            }
            if (syntaxNode2 != null)
            {
                returnstring = returnstring + " " + syntaxNode2.ToString() + " ";
            }
            return returnstring;
        }
    }
}