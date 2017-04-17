namespace p4_interpreter_01
{
    public class TypeValueKeywords : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;

        public TypeValueKeywords(ParserContext parserContext, SyntaxNode syntaxNode) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode = syntaxNode;
        }
    }
}