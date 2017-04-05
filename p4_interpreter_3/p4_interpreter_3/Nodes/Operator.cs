namespace p4_interpreter_3.expressions
{
    public class Operator : Expression
    {

        private string op;

        public Operator(ParserContext context, string op) : base(context)
        {
            this.op = op;
        }

        public override object Value
        {
            get { return op; }
        }
    }
}