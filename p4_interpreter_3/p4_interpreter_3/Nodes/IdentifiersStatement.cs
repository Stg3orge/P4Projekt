namespace p4_interpreter_3.expressions
{
    public class IdentifiersStatement : Statement
    {

        private string v;
        private Statement statement;

        public IdentifiersStatement(ParserContext context, string v, Statement statement) : base(context)
        {

            this.v = v;
            this.statement = statement;
        }

        public override string ToString()
        {
            string returnstring = "";

            if (v != null)
            {
                returnstring += " " + v + " ";
            }
            if (statement != null)
            {
                returnstring += " " + statement.ToString() + " ";
            }

            return returnstring;

        }

    }
}