namespace p4_interpreter_01
{
    public class RuleStatementPrefabMethods : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode PrefabMethods { get; private set; }
        public SyntaxNode CallingParameters { get; private set; }

        public RuleStatementPrefabMethods(ParserContext parserContext, SyntaxNode prefabMethods, SyntaxNode callingParameters)
            : base(parserContext)
        {
            this.parserContext = parserContext;
            this.PrefabMethods = prefabMethods;
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