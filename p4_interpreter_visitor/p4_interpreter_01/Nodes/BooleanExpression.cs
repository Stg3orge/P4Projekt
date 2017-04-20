namespace p4_interpreter_01
{
    public class BooleanExpression : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Value { get; private set; }
        public SyntaxNode Expression { get; private set; }
        public SyntaxNode comparisonoperator { get; private set; }
        public SyntaxNode Value2 { get; private set; }
        public SyntaxNode Expression2 { get; private set; }
        public SyntaxNode BooleanExpressionExtension { get; private set; }

        public BooleanExpression(ParserContext parserContext, SyntaxNode value, SyntaxNode expression,
            SyntaxNode comparisonoperator, SyntaxNode value2, SyntaxNode expression2, SyntaxNode booleanExpressionExtension)
            : base(parserContext)
        {
            this.parserContext = parserContext;
            this.Value = value;
            this.Expression = expression;
            this.comparisonoperator = comparisonoperator;
            this.Value2 = value2;
            this.Expression2 = expression2;
            this.BooleanExpressionExtension = booleanExpressionExtension;

            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
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
            if (Expression != null)
            {
                returnstring = returnstring + " " + Expression.ToString() + " ";
            }
            if (comparisonoperator != null)
            {
                returnstring = returnstring + " " + comparisonoperator.ToString() + " ";
            }
            if (Value2 != null)
            {
                returnstring = returnstring + " " + Value2.ToString() + " ";
            }
            if (Expression2 != null)
            {
                returnstring = returnstring + " " + Expression2.ToString() + " ";
            }
            if (BooleanExpressionExtension != null)
            {
                returnstring = returnstring + " " + BooleanExpressionExtension.ToString() + " ";
            }
            return returnstring;
        }
    }
}