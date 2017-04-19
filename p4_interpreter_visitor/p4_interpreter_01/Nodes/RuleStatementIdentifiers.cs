namespace p4_interpreter_01
{
    public class RuleStatementIdentifiers : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Identifiers { get; private set; }
        public SyntaxNode CallingParameters { get; private set; }

        public RuleStatementIdentifiers(ParserContext parserContext, SyntaxNode identifiers, SyntaxNode callingParameters)
            : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Identifiers = identifiers;
            this.CallingParameters = callingParameters;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
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
            if (CallingParameters != null)
            {
                returnstring = returnstring + " " + CallingParameters.ToString() + " ";
            }
            return returnstring;
        }
    }
}