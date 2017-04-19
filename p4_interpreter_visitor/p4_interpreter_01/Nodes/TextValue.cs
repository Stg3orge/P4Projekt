namespace p4_interpreter_01
{
    public class TextValue : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode TextPrime { get; private set; }
        public string StringValue { get; private set; }

        public TextValue(ParserContext parserContext, string stringValue, SyntaxNode textPrime) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.StringValue = stringValue;
            this.TextPrime = textPrime;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
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
            if (TextPrime != null)
            {
                returnstring = returnstring + " " + TextPrime.ToString() + " ";
            }
            return returnstring;
        }
    }
}