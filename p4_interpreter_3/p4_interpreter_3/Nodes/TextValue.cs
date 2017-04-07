namespace p4_interpreter_3.expressions
{
    public class TextValue : Statement
    {

        private string v;
        private Statement statement;

        public TextValue(ParserContext context, string v, Statement statement) : base(context)
        {

            this.v = v;
            this.statement = statement;
        }
    }
}