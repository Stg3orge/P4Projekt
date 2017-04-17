namespace p4_interpreter_01
{
    public class TypeCreator : SyntaxNode
    {
        private ParserContext parserContext;
        private string v;

        public TypeCreator(ParserContext parserContext, string v) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.v = v;
        }
    }
}