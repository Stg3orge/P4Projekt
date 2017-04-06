namespace p4_interpreter_3.expressions
{
    public class BooleanValue : Statement
    {

        private string v;

        public BooleanValue(ParserContext context, string v) : base(context)
        {

            this.v = v;
        }
    }
}