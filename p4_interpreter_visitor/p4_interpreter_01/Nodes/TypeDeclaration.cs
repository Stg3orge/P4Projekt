namespace p4_interpreter_01
{
    public class TypeDeclaration : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;
        private string v;

        public TypeDeclaration(ParserContext parserContext, SyntaxNode syntaxNode, string v) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode = syntaxNode;
            this.v = v;
        }
    }
}