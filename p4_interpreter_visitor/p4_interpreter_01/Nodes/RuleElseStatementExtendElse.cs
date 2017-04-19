namespace p4_interpreter_01
{
    public class RuleElseStatementExtendElse : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode Commands { get; private set; }

        public RuleElseStatementExtendElse(ParserContext parserContext, SyntaxNode commands) : base(parserContext)
        {
            this.parserContext = parserContext;
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
            if (Commands != null)
            {
                returnstring = returnstring + " " + Commands.ToString() + " ";
            }
            return returnstring;
        }
    }
}