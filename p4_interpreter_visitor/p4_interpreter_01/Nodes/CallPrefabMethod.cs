namespace p4_interpreter_01
{
    public class CallPrefabMethod : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode1;
        private SyntaxNode syntaxNode2;
        private SyntaxNode syntaxNode3;

        public CallPrefabMethod(ParserContext parserContext, SyntaxNode syntaxNode1, SyntaxNode syntaxNode2, SyntaxNode syntaxNode3) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode1 = syntaxNode1;
            this.syntaxNode2 = syntaxNode2;
            this.syntaxNode3 = syntaxNode3;
        }
    }
}