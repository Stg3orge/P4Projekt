namespace p4_interpreter_3.expressions
{
    public class Prefix : Statement
    {

        private string v;

        public Prefix(ParserContext context, string v) : base(context)
        {

            this.v = v;
        }
    }
}