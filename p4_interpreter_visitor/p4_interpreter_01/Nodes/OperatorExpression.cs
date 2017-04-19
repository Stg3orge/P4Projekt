namespace p4_interpreter_01
{
    public class OperatorExpression : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode OperatorNode { get; private set; }
        public SyntaxNode Value { get; private set; }
        public SyntaxNode Expression { get; private set; }

        public OperatorExpression(ParserContext parserContext, SyntaxNode operatorNode, SyntaxNode value,
            SyntaxNode expression) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.OperatorNode = operatorNode;
            this.Value = value;
            this.Expression = expression;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (OperatorNode != null)
            {
                returnstring = returnstring + " " + OperatorNode.ToString() + " ";
            }
            if (Value != null)
            {
                returnstring = returnstring + " " + Value.ToString() + " ";
            }
            if (Expression != null)
            {
                returnstring = returnstring + " " + Expression.ToString() + " ";
            }
            return returnstring;
        }
    }
}