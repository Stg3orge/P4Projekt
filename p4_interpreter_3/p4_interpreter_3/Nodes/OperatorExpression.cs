namespace p4_interpreter_3.expressions
{
    public class OperatorExpression : Expression
    {

        private Statement statement1;
        private Statement statement2;
        private Expression expression2;

        public OperatorExpression(ParserContext context, Statement statement1, Statement statement2, Expression expression2) : base(context)
        {

            this.statement1 = statement1;
            this.statement2 = statement2;
            this.expression2 = expression2;
        }

        public override object Value
        {
            get { return null; }
        }

        public override string ToString()
        {
            return statement1.ToString() + " " + statement2.ToString() + " " + expression2.ToString() + " ";
        }
    }
}