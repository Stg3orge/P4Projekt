namespace p4_interpreter_3.expressions
{
    public class BooleanExpression : Statement
    {

        private Statement statement1;
        private Statement statement2;
        private Statement statement3;
        private Statement statement4;
        private Statement statement5;
        private Statement statement6;

        public BooleanExpression(ParserContext context, Statement statement1, Statement statement2, Statement statement3, Statement statement4, Statement statement5, Statement statement6) : base(context)
        {

            this.statement1 = statement1;
            this.statement2 = statement2;
            this.statement3 = statement3;
            this.statement4 = statement4;
            this.statement5 = statement5;
            this.statement6 = statement6;
        }
    }
}