namespace p4_interpreter_01
{
    public class TypeValueInteger : SyntaxNode, IVisitable
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;
        private string v;

        public TypeValueInteger(ParserContext parserContext, SyntaxNode syntaxNode, string v) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode = syntaxNode;
            this.v = v;
            Nodes.Add(this);
        }

        public new void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (syntaxNode != null)
            {
                returnstring = returnstring + " " + syntaxNode.ToString() + " ";
            }
            if (v != null)
            {
                returnstring = returnstring + " " + v.ToString() + " ";
            }
            return returnstring;
        }
    }
}