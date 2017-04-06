namespace p4_interpreter_3.expressions
{
    public class AssignmentStatement : Statement
    {

        private Statement statement;
        private Statement statement2;
        private Expression expression2;

        public AssignmentStatement(ParserContext context, Statement statement, Statement statement2, Expression expression2) : base(context)
        {
            this.statement = statement;
            this.statement2 = statement2;
            this.expression2 = expression2;
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
            if (expression2 != null)
            {
                returnstring = returnstring + " " + expression2.ToString() + " ";
            }
            return returnstring;
        }
    }
}