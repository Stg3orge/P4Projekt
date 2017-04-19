namespace p4_interpreter_01
{
    public class Prefix : SyntaxNode
    {
        public object PrefixToken { get; private set; }

        private ParserContext parserContext;

        public Prefix(ParserContext parserContext, object prefixToken) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.PrefixToken = prefixToken;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (PrefixToken != null)
            {
                returnstring = returnstring + " " + PrefixToken.ToString() + " ";
            }
            return returnstring;
        }
    }
}