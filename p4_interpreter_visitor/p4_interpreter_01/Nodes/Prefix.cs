namespace p4_interpreter_01
{
    public class Prefix : SyntaxNode
    {
        private object p;
        private ParserContext parserContext;

        public Prefix(ParserContext parserContext, object p) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.p = p;
        }
    }
}