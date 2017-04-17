namespace p4_interpreter_01
{
    public class MethodDeclaration : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode1;
        private SyntaxNode syntaxNode2;
        private SyntaxNode syntaxNode3;
        private SyntaxNode syntaxNode4;

        public MethodDeclaration(ParserContext parserContext, SyntaxNode syntaxNode1, SyntaxNode syntaxNode2, SyntaxNode syntaxNode3, SyntaxNode syntaxNode4) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode1 = syntaxNode1;
            this.syntaxNode2 = syntaxNode2;
            this.syntaxNode3 = syntaxNode3;
            this.syntaxNode4 = syntaxNode4;
        }
    }
}