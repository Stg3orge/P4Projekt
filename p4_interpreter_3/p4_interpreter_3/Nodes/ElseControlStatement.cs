namespace p4_interpreter_3.expressions
{
    public class ElseControlStatement : Statement
    {

        private Statement statement;

        public ElseControlStatement(ParserContext context, Statement statement) : base(context)
        {

            this.statement = statement;
        }
    }
}