namespace p4_interpreter_01
{
    public class TypeValueCreatorPoint : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode1;
        private SyntaxNode syntaxNode2;
        private string v1;
        private string v2;

        public TypeValueCreatorPoint(ParserContext parserContext, SyntaxNode syntaxNode1, string v1, SyntaxNode syntaxNode2, string v2) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode1 = syntaxNode1;
            this.v1 = v1;
            this.syntaxNode2 = syntaxNode2;
            this.v2 = v2;
        }
    }
}