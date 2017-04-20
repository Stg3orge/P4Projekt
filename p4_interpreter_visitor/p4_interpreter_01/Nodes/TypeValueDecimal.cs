namespace p4_interpreter_01
{
    public class TypeValueDecimal : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Prefix { get; private set; }
        public string DecimalValue { get; private set; }

        public TypeValueDecimal(ParserContext parserContext, SyntaxNode prefix, string decimalValue) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Prefix = prefix;
            this.DecimalValue = decimalValue;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
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
            return returnstring;
        }
    }
}