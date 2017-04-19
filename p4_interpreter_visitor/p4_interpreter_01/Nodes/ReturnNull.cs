namespace p4_interpreter_01
{
    public class ReturnNull : SyntaxNode
    {
        public object ReturnObj { get; private set; }
        private ParserContext parserContext;

        public ReturnNull(ParserContext parserContext, object returnObj) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.ReturnObj = returnObj;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (ReturnObj != null)
            {
                returnstring = returnstring + " " + ReturnObj.ToString() + " ";
            }
            return returnstring;
        }
    }
}