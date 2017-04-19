namespace p4_interpreter_01
{
    public class Operator : SyntaxNode
    {
        private ParserContext parserContext;
        public string operatorToken { get; private set; }

        public Operator(ParserContext parserContext, string operatorToken) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.operatorToken = operatorToken;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (operatorToken != null)
            {
                returnstring = returnstring + " " + operatorToken.ToString() + " ";
            }
            return returnstring;
        }
    }
}