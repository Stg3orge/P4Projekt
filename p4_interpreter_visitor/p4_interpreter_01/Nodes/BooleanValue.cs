namespace p4_interpreter_01
{
    public class BooleanValue : SyntaxNode
    {
        private ParserContext parserContext;
        private string v;

        public BooleanValue(ParserContext parserContext, string v) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.v = v;
        }
    }
}