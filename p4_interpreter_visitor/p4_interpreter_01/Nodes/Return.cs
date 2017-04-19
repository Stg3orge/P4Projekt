namespace p4_interpreter_01
{
    public class Return : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Value { get; private set; }
        public SyntaxNode Expression { get; private set; }

        public Return(ParserContext parserContext, SyntaxNode value, SyntaxNode expression) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Value = value;
            this.Expression = expression;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
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