namespace p4_interpreter_01
{
    public class TypeValueInteger : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Prefix { get; private set; }
        public string IntegerValue { get; private set; }

        public TypeValueInteger(ParserContext parserContext, SyntaxNode prefix, string integerValue) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Prefix = prefix;
            this.IntegerValue = integerValue;
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
            if (IntegerValue != null)
            {
                returnstring = returnstring + " " + IntegerValue.ToString() + " ";
            }
            return returnstring;
        }
    }
}