namespace p4_interpreter_01
{
    public class TypeDeclaration : SyntaxNode
    {
        private ParserContext parserContext;

        public SyntaxNode Type { get; private set; }
        public string Identifier { get; private set; }

        public TypeDeclaration(ParserContext parserContext, SyntaxNode type, string identifier) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Type = type;
            this.Identifier = identifier;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (Type != null)
            {
                returnstring = returnstring + " " + Type.ToString() + " ";
            }
            if (Identifier != null)
            {
                returnstring = returnstring + " " + Identifier.ToString() + " ";
            }
            return returnstring;
        }
    }
}