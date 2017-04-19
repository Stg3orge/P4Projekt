namespace p4_interpreter_01
{
    public class BooleanValue : SyntaxNode
    {
        private ParserContext parserContext;
        public string TrueOrFalseToken { get; private set; }

        public BooleanValue(ParserContext parserContext, string trueOrFalseToken) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.TrueOrFalseToken = trueOrFalseToken;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (TrueOrFalseToken != null)
            {
                returnstring = returnstring + " " + TrueOrFalseToken.ToString() + " ";
            }
            return returnstring;
        }
    }
}