namespace p4_interpreter_01
{
    public class TextIdentifiers : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Identifiers { get; private set; }
        public SyntaxNode TextPrime { get; private set; }

        public TextIdentifiers(ParserContext parserContext, SyntaxNode identifiers, SyntaxNode textPrime)
            : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Identifiers = identifiers;
            this.TextPrime = textPrime;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (Identifiers != null)
            {
                returnstring = returnstring + " " + Identifiers.ToString() + " ";
            }
            if (TextPrime != null)
            {
                returnstring = returnstring + " " + TextPrime.ToString() + " ";
            }
            return returnstring;
        }
    }
}