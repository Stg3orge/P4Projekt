namespace p4_interpreter_01
{
    public class CallPrefabMethod : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Identifiers { get; private set; }
        public SyntaxNode PrefabMethods { get; private set; }
        public SyntaxNode CallingParameters { get; private set; }

        public CallPrefabMethod(ParserContext parserContext, SyntaxNode identifiers, SyntaxNode prefabMethods,
            SyntaxNode callingParameters) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Identifiers = identifiers;
            this.PrefabMethods = prefabMethods;
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
            if (PrefabMethods != null)
            {
                returnstring = returnstring + " " + PrefabMethods.ToString() + " ";
            }
            if (CallingParameters != null)
            {
                returnstring = returnstring + " " + CallingParameters.ToString() + " ";
            }
            return returnstring;
        }
    }
}