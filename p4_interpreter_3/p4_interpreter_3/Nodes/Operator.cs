namespace p4_interpreter_3.expressions
{
    public class Operator : Statement
    {

        private string op;

        public Operator(ParserContext context, string op) : base(context)
        {
            this.op = op;
        }


    }
}