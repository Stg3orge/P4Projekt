namespace p4_interpreter_01
{
    public class MethodTypeCreator : SyntaxNode
    {
        private ParserContext parserContext;
        public string MethodTypeToken { get; private set; }

        public MethodTypeCreator(ParserContext parserContext, string methodTypeToken) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.MethodTypeToken = methodTypeToken;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (MethodTypeToken != null)
            {
                returnstring = returnstring + " " + MethodTypeToken.ToString() + " ";
            }
            return returnstring;
        }
    }
}