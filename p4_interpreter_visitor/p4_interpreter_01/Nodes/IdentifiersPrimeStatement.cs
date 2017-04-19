namespace p4_interpreter_01
{
    public class IdentifiersPrimeStatement : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode IdentifiersPrime { get; private set; }
        public string Identifier { get; private set; }

        public IdentifiersPrimeStatement(ParserContext parserContext, string identifier, SyntaxNode identifiersPrime)
            : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Identifier = identifier;
            this.IdentifiersPrime = identifiersPrime;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (Identifier != null)
            {
                returnstring = returnstring + " " + Identifier + " ";
            }
            if (IdentifiersPrime != null)
            {
                returnstring = returnstring + " " + IdentifiersPrime.ToString() + " ";
            }
            return returnstring;
        }
    }
}