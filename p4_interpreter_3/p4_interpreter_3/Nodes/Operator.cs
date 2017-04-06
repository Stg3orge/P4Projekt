namespace p4_interpreter_3.expressions
{
    public class Operator : Statement
    {

        private string op;

        public Operator(ParserContext context, string op) : base(context)
        {
            this.op = op;
        }

        public override string ToString()
        {
            string returnstring = "";

            if (op != null)
            {
                returnstring = returnstring + " " + op + " ";
            }

            return returnstring;
        }
    }
}