namespace p4_interpreter_01
{
    public class TypeValueKeywords : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode ValueKeywords { get; private set; }

        public TypeValueKeywords(ParserContext parserContext, SyntaxNode valueKeywords) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.ValueKeywords = valueKeywords;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (ValueKeywords != null)
            {
                returnstring = returnstring + " " + ValueKeywords.ToString() + " ";
            }
            return returnstring;
        }
    }
}