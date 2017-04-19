namespace p4_interpreter_01
{
    public class MethodParameterComma : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Value { get; private set; }
        public SyntaxNode CallingParameter { get; private set; }

        public MethodParameterComma(ParserContext parserContext, SyntaxNode value, SyntaxNode callingParameter)
            : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Value = value;
            this.CallingParameter = callingParameter;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (Value != null)
            {
                returnstring = returnstring + " " + Value.ToString() + " ";
            }
            if (CallingParameter != null)
            {
                returnstring = returnstring + " " + CallingParameter.ToString() + " ";
            }
            return returnstring;
        }
    }
}