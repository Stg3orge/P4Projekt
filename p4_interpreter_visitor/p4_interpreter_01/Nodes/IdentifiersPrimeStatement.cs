namespace p4_interpreter_01
{
    public class IdentifiersPrimeStatement : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;
        private string v;

        public IdentifiersPrimeStatement(ParserContext parserContext, string v, SyntaxNode syntaxNode) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.v = v;
            this.syntaxNode = syntaxNode;
        }
    }
}