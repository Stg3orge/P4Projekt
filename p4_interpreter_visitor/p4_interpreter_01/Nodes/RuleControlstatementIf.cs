namespace p4_interpreter_01
{
    public class RuleControlstatementIf : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode BooleanExpression { get; private set; }
        public SyntaxNode Commands { get; private set; }
        public SyntaxNode ElseIfStatementExtend { get; private set; }

        public RuleControlstatementIf(ParserContext parserContext, SyntaxNode booleanExpression, SyntaxNode commands,
            SyntaxNode elseIfStatementExtend) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.BooleanExpression = booleanExpression;
            this.Commands = commands;
            this.ElseIfStatementExtend = elseIfStatementExtend;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
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
            if (ElseIfStatementExtend != null)
            {
                returnstring = returnstring + " " + ElseIfStatementExtend.ToString() + " ";
            }
            return returnstring;
        }
    }
}