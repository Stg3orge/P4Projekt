namespace p4_interpreter_01
{
    public class CallMethod : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Identifiers { get; private set; }
        public SyntaxNode Identifiers2 { get; private set; }
        public SyntaxNode CallingParameters { get; private set; }

        public CallMethod(ParserContext parserContext, SyntaxNode identifiers, SyntaxNode identifiers2,
            SyntaxNode callingParameters) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Identifiers = identifiers;
            this.Identifiers2 = identifiers2;
            this.CallingParameters = callingParameters;
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
            if (Identifiers2 != null)
            {
                returnstring = returnstring + " " + Identifiers2.ToString() + " ";
            }
            if (CallingParameters != null)
            {
                returnstring = returnstring + " " + CallingParameters.ToString() + " ";
            }
            return returnstring;
        }
    }
}