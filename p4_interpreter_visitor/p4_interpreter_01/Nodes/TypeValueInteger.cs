namespace p4_interpreter_01
{
    public class TypeValueInteger : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;
        private string v;

        public TypeValueInteger(ParserContext parserContext, SyntaxNode syntaxNode, string v) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode = syntaxNode;
            this.v = v;
        }
    }
}