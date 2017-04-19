namespace p4_interpreter_01
{
    public class TypeCreator : SyntaxNode
    {
        private ParserContext parserContext;

        public string DatatypeToken { get; private set; }


        public TypeCreator(ParserContext parserContext, string datatypeToken) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.DatatypeToken = datatypeToken;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (DatatypeToken != null)
            {
                returnstring = returnstring + " " + DatatypeToken.ToString() + " ";
            }
            return returnstring;
        }
    }
}