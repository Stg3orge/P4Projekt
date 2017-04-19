namespace p4_interpreter_01
{
    public class TypeCreator : SyntaxNode
    {
        private ParserContext parserContext;

        public string V { get; private set; }


        public TypeCreator(ParserContext parserContext, string v) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.V = v;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (V != null)
            {
                returnstring = returnstring + " " + V.ToString() + " ";
            }
            return returnstring;
        }
    }
}