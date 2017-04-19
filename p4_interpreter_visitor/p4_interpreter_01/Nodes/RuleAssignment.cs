namespace p4_interpreter_01
{
    public class RuleAssignment : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Identifiers { get; private set; }
        public SyntaxNode Value { get; private set; }
        public SyntaxNode Expression { get; private set; }

        public RuleAssignment(ParserContext parserContext, SyntaxNode identifiers, SyntaxNode value,
            SyntaxNode expression) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Identifiers = identifiers;
            this.Value = value;
            this.Expression = expression;
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
            if (Value != null)
            {
                returnstring = returnstring + " " + Value.ToString() + " ";
            }
            if (Expression != null)
            {
                returnstring = returnstring + " " + Expression.ToString() + " ";
            }
            return returnstring;
        }
    }
}