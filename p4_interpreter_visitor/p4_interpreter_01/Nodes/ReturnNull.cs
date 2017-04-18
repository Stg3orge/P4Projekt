namespace p4_interpreter_01
{
    public class ReturnNull : SyntaxNode
    {
        private object p;
        private ParserContext parserContext;

        public ReturnNull(ParserContext parserContext, object p) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.p = p;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (p != null)
            {
                returnstring = returnstring + " " + p.ToString() + " ";
            }
            return returnstring;
        }
    }
}