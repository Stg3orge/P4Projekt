namespace p4_interpreter_01
{
    public class RuleControlStatements : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;

        public RuleControlStatements(ParserContext parserContext, SyntaxNode syntaxNode) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode = syntaxNode;
        }
    }
}