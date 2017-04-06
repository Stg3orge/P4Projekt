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
            return statement.ToString() + " " + statement2.ToString() + " " + expression2.ToString() + " ";
        }
    }
}