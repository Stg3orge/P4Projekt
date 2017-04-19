namespace p4_interpreter_01
{
    public class RuleControlStatements : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode ControlStatements { get; private set; }

        public RuleControlStatements(ParserContext parserContext, SyntaxNode controlStatements) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.ControlStatements = controlStatements;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (ControlStatements != null)
            {
                returnstring = returnstring + " " + ControlStatements.ToString() + " ";
            }
            return returnstring;
        }
    }
}