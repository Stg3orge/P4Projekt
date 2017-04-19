namespace p4_interpreter_01
{
    public class TypeValueIdentifier : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Identifiers { get; private set; }

        public TypeValueIdentifier(ParserContext parserContext, SyntaxNode identifiers) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Identifiers = identifiers;
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
            return returnstring;
        }
    }
}