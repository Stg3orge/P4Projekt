namespace p4_interpreter_01
{
    public class IdentifiersStatement : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;
        private string v;

        public IdentifiersStatement(ParserContext parserContext, string v, SyntaxNode syntaxNode) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.v = v;
            this.syntaxNode = syntaxNode;
        }
    }
}