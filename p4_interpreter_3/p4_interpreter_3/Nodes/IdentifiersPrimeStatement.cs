namespace p4_interpreter_3.expressions
{
    public class IdentifiersPrimeStatement : Statement
    {

        private string v;
        private Statement statement;

        public IdentifiersPrimeStatement(ParserContext context, string v, Statement statement) : base(context)
        {
            this.v = v;
            this.statement = statement;
        }


        public override string ToString()
        {
            return v + " " + statement.ToString() + " ";
        }
    }
}