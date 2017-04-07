namespace p4_interpreter_3.expressions
{
    public class MethodParameter : Statement
    {

        private Statement statement1;
        private Statement statement2;
        private Statement statement3;

        public MethodParameter(ParserContext context, Statement statement1, Statement statement2, Statement statement3) : base(context)
        {

            this.statement1 = statement1;
            this.statement2 = statement2;
            this.statement3 = statement3;
        }
    }
}