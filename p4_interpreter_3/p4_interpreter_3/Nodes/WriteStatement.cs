namespace p4_interpreter_3.expressions
{
    public class WriteStatement : Statement
    {
        private Expression expression;

        public WriteStatement(ParserContext context, Expression expression) : base(context)
        {
            this.expression = expression;
        }
    }
}