namespace p4_interpreter_01
{
    public class MethodTypeCreator : SyntaxNode
    {
        private ParserContext parserContext;
        private string v;

        public MethodTypeCreator(ParserContext parserContext, string v) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.v = v;
        }
    }
}