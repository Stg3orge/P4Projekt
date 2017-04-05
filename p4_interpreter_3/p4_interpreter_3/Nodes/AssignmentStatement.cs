namespace p4_interpreter_3.expressions
{
    public class AssignmentStatement : Statement
    {

        private Statement statement;
        private Expression expression1;
        private Expression expression2;

        public AssignmentStatement(ParserContext context, Statement statement, Expression expression1, Expression expression2) : base(context)
        {
            this.statement = statement;
            this.expression1 = expression1;
            this.expression2 = expression2;
        }
    }
}