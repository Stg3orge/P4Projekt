namespace p4_interpreter_01
{
    public class WriteStatement : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;

        public WriteStatement(ParserContext parserContext, SyntaxNode syntaxNode) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode = syntaxNode;
        }
    }
}