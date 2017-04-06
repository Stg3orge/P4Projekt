namespace p4_interpreter_3.expressions
{
    public class WriteStatement : Statement
    {
        private Statement statement;

        public WriteStatement(ParserContext context, Statement statement) : base(context)
        {
            this.statement = statement;
        }
        public override string ToString()
        {
            string returnstring = "";
            if (statement != null)
            {
                returnstring = returnstring + " " + statement.ToString() + " ";
            }
            return returnstring;
        }
    }
}