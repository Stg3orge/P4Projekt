namespace p4_interpreter_01
{
    public class WriteStatement : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Text { get; private set; }

        public WriteStatement(ParserContext parserContext, SyntaxNode text) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Text = text;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (Text != null)
            {
                returnstring = returnstring + " " + Text.ToString() + " ";
            }
            return returnstring;
        }
    }
}