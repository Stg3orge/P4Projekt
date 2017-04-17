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
        }
    }
}