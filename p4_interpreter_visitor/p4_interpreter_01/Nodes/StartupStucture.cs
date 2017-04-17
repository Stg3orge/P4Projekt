namespace p4_interpreter_01
{
    public class StartupStucture : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode1;
        private SyntaxNode syntaxNode2;
        private SyntaxNode syntaxNode3;
        private SyntaxNode syntaxNode4;
        private SyntaxNode syntaxNode5;
        private SyntaxNode syntaxNode6;
        private SyntaxNode syntaxNode7;

        public StartupStucture(ParserContext parserContext, SyntaxNode syntaxNode1, SyntaxNode syntaxNode2, SyntaxNode syntaxNode3, SyntaxNode syntaxNode4, SyntaxNode syntaxNode5, SyntaxNode syntaxNode6, SyntaxNode syntaxNode7) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode1 = syntaxNode1;
            this.syntaxNode2 = syntaxNode2;
            this.syntaxNode3 = syntaxNode3;
            this.syntaxNode4 = syntaxNode4;
            this.syntaxNode5 = syntaxNode5;
            this.syntaxNode6 = syntaxNode6;
            this.syntaxNode7 = syntaxNode7;
        }
    }
}