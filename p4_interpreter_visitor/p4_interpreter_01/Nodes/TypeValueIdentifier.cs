namespace p4_interpreter_01
{
    public class TypeValueIdentifier : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;

        public TypeValueIdentifier(ParserContext parserContext, SyntaxNode syntaxNode) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode = syntaxNode;
        }
    }
}