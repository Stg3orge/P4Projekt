namespace p4_interpreter_01
{
    public class Prefix : SyntaxNode
    {
        private object p;
        private ParserContext parserContext;

        public Prefix(ParserContext parserContext, object p) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.p = p;
            Nodes.Add(this);
        }

        public new void Accept(IVisitor visitor)
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