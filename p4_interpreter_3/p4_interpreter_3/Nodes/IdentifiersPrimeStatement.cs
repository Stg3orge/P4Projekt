namespace p4_interpreter_3.expressions
{
    public class IdentifiersPrimeStatement : Expression
    {

        private string v;
        private Statement statement;

        public IdentifiersPrimeStatement(ParserContext context, string v, Statement statement) : base(context)
        {
            this.v = v;
            this.statement = statement;
        }
    }
}