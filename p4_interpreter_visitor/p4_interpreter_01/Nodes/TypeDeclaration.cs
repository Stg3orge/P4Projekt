namespace p4_interpreter_01
{
    public class TypeDeclaration : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;
        private string v;

        public TypeDeclaration(ParserContext parserContext, SyntaxNode syntaxNode, string v) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode = syntaxNode;
            this.v = v;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
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