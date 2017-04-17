namespace p4_interpreter_01
{
    public class TypeValueBoolean : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;

        public TypeValueBoolean(ParserContext parserContext, SyntaxNode syntaxNode) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode = syntaxNode;
        }
    }
}