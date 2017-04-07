namespace p4_interpreter_3.expressions
{
    public class TextPrimeStringValue : Statement
    {

        private string v;
        private Statement statement;

        public TextPrimeStringValue(ParserContext context, string v, Statement statement) : base(context)
        {

            this.v = v;
            this.statement = statement;
        }
    }
}