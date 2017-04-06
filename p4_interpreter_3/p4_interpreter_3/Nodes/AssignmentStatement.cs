namespace p4_interpreter_3.expressions
{
    public class AssignmentStatement : Statement
    {

        private Statement statement;
        private Statement statement2;
        private Statement statement3;

        public AssignmentStatement(ParserContext context, Statement statement, Statement statement2, Statement statement3) : base(context)
        {
            this.statement = statement;
            this.statement2 = statement2;
            this.statement3 = statement3;
        }


        public override string ToString()
        {
            string returnstring = "";
            if (statement != null)
            {
                returnstring = returnstring + " " + statement.ToString() + " ";
            }
            if (statement2 != null)
            {
                returnstring = returnstring + " " + statement2.ToString() + " ";
            }
            if (statement3 != null)
            {
                returnstring = returnstring + " " + statement3.ToString() + " ";
            }
            return returnstring;
        }
    }
}