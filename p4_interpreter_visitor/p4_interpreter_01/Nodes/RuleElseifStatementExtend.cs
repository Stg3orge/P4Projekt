namespace p4_interpreter_01
{
    public class RuleElseifStatementExtend : SyntaxNode
    {
        private ParserContext parserContext;
        public SyntaxNode ElseStatementExtend { get; private set; }

        public RuleElseifStatementExtend(ParserContext parserContext, SyntaxNode elseStatementExtend) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.ElseStatementExtend = elseStatementExtend;
            Nodes.Add(this);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (ElseStatementExtend != null)
            {
                returnstring = returnstring + " " + ElseStatementExtend.ToString() + " ";
            }
            return returnstring;
        }
    }
}