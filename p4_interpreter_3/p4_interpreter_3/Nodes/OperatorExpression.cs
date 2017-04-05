namespace p4_interpreter_3.expressions
{
    public class OperatorExpression : Statement
    {

        private Statement statement1;
        private Expression expression1;
        private Expression expression2;

        public OperatorExpression(ParserContext context, Statement statement1, Expression expression1, Expression expression2) : base(context)
        {

            this.statement1 = statement1;
            this.expression1 = expression1;
            this.expression2 = expression2;
        }
    }
}