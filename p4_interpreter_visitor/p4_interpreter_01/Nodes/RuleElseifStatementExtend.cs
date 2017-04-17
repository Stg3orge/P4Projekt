namespace p4_interpreter_01
{
    public class RuleElseifStatementExtend : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;

        public RuleElseifStatementExtend(ParserContext parserContext, SyntaxNode syntaxNode) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode = syntaxNode;
            Nodes.Add(this);
        }

        public new void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (syntaxNode != null)
            {
                returnstring = returnstring + " " + syntaxNode.ToString() + " ";
            }
            return returnstring;
        }
    }
}