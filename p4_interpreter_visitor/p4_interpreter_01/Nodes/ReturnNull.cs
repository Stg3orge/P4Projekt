namespace p4_interpreter_01
{
    public class ReturnNull : SyntaxNode
    {
        private object p;
        private ParserContext parserContext;

        public ReturnNull(ParserContext parserContext, object p) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.p = p;
        }
    }
}