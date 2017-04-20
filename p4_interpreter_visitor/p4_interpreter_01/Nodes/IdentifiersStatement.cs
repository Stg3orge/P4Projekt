namespace p4_interpreter_01
{
    public class IdentifiersStatement : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode IdentifiersPrime { get; private set; }
        public string Identifier { get; private set; }

        public IdentifiersStatement(ParserContext parserContext, string identifier, SyntaxNode identifiersPrime) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Identifier = identifier;
            this.IdentifiersPrime = identifiersPrime;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
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