namespace p4_interpreter_3.expressions
{
    public class IdentifiersPrimeStatement : Statement
    {

        private string v;
        private Statement statement;

        public IdentifiersPrimeStatement(ParserContext context, string v, Statement statement) : base(context)
        {
            this.v = v;
            this.statement = statement;
        }

<<<<<<< HEAD
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

=======

        public override string ToString()
        {
            return v + " " + statement.ToString() + " ";
>>>>>>> 24310a8cf9f1ebce08c35a869f3b7aea9a472e61
        }
    }
}