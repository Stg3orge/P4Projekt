namespace p4_interpreter_01
{
    public class ValueKeywords : SyntaxNode
    {
        private ParserContext parserContext;
        public string Time { get; private set; }

        public ValueKeywords(ParserContext parserContext, string time) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Time = time;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (Time != null)
            {
                returnstring = returnstring + " " + Time.ToString() + " ";
            }
            return returnstring;
        }
    }
}