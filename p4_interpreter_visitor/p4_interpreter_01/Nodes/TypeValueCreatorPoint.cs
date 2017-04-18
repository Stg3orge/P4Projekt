namespace p4_interpreter_01
{
    public class TypeValueCreatorPoint : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode1;
        private SyntaxNode syntaxNode2;
        private string v1;
        private string v2;

        public TypeValueCreatorPoint(ParserContext parserContext, SyntaxNode syntaxNode1, string v1,
            SyntaxNode syntaxNode2, string v2) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode1 = syntaxNode1;
            this.v1 = v1;
            this.syntaxNode2 = syntaxNode2;
            this.v2 = v2;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (syntaxNode1 != null)
            {
                returnstring = returnstring + " " + syntaxNode1.ToString() + " ";
            }
            if (v1 != null)
            {
                returnstring = returnstring + " " + v1.ToString() + " ";
            }
            if (syntaxNode2 != null)
            {
                returnstring = returnstring + " " + syntaxNode2.ToString() + " ";
            }
            if (v2 != null)
            {
                returnstring = returnstring + " " + v2.ToString() + " ";
            }
            return returnstring;
        }
    }
}