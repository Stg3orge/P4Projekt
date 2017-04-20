namespace p4_interpreter_01
{
    public class TypeValueBoolean : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode BooleanValue { get; private set; }

        public TypeValueBoolean(ParserContext parserContext, SyntaxNode booleanValue) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.BooleanValue = booleanValue;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (BooleanValue != null)
            {
                returnstring = returnstring + " " + BooleanValue.ToString() + " ";
            }
            return returnstring;
        }
    }
}