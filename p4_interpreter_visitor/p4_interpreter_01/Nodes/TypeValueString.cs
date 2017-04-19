namespace p4_interpreter_01
{
    public class TypeValueString : SyntaxNode
    {
        private ParserContext parserContext;
        public string StringValue { get; private set; }

        public TypeValueString(ParserContext parserContext, string stringValue) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.StringValue = stringValue;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (StringValue != null)
            {
                returnstring = returnstring + " " + StringValue.ToString() + " ";
            }
            return returnstring;
        }
    }
}