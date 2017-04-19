namespace p4_interpreter_01
{
    public class TypeValueCreatorPoint : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Prefix { get; private set; }
        public SyntaxNode Prefix2 { get; private set; }
        public string DecimalValue { get; private set; }
        public string DecimalValue2 { get; private set; }

        public TypeValueCreatorPoint(ParserContext parserContext, SyntaxNode prefix, string decimalValue,
            SyntaxNode prefix2, string decimalValue2) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Prefix = prefix;
            this.DecimalValue = decimalValue;
            this.Prefix2 = prefix2;
            this.DecimalValue2 = decimalValue2;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (Prefix != null)
            {
                returnstring = returnstring + " " + Prefix.ToString() + " ";
            }
            if (DecimalValue != null)
            {
                returnstring = returnstring + " " + DecimalValue.ToString() + " ";
            }
            if (Prefix2 != null)
            {
                returnstring = returnstring + " " + Prefix2.ToString() + " ";
            }
            if (DecimalValue2 != null)
            {
                returnstring = returnstring + " " + DecimalValue2.ToString() + " ";
            }
            return returnstring;
        }
    }
}