namespace p4_interpreter_3.expressions
{
    public class ValueKeywords : Statement
    {

        private string v;

        public ValueKeywords(ParserContext context, string v) : base(context)
        {

            this.v = v;
        }
    }
}