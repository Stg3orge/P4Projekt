namespace p4_interpreter_01
{
    public class RuleControlstatementWhile : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode BooleanExpression { get; private set; }
        public SyntaxNode Commands { get; private set; }

        public RuleControlstatementWhile(ParserContext parserContext, SyntaxNode booleanExpression, SyntaxNode commands)
            : base(parserContext)
        {
            this.parserContext = parserContext;
            this.BooleanExpression = booleanExpression;
            this.Commands = commands;
            Nodes.Add(this);
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (BooleanExpression != null)
            {
                returnstring = returnstring + " " + BooleanExpression.ToString() + " ";
            }
            if (Commands != null)
            {
                returnstring = returnstring + " " + Commands.ToString() + " ";
            }
            return returnstring;
        }
    }
}