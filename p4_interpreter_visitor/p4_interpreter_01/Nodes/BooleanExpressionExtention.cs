namespace p4_interpreter_01
{
    public class BooleanExpressionExtention : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode logicaloperator { get; private set; }
        public SyntaxNode BooleanExpression { get; private set; }

        public BooleanExpressionExtention(ParserContext parserContext, SyntaxNode logicaloperator, SyntaxNode booleanExpression)
            : base(parserContext)
        {
            this.parserContext = parserContext;
            this.logicaloperator = logicaloperator;
            this.BooleanExpression = booleanExpression;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (logicaloperator != null)
            {
                returnstring = returnstring + " " + logicaloperator.ToString() + " ";
            }
            if (BooleanExpression != null)
            {
                returnstring = returnstring + " " + BooleanExpression.ToString() + " ";
            }
            return returnstring;
        }
    }
}