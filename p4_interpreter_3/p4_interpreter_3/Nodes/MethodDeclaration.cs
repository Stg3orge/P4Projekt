namespace p4_interpreter_3.expressions
{
    public class MethodDeclaration : Statement
    {

        private string v;
        private Statement statement1;
        private Statement statement2;

        public MethodDeclaration(ParserContext context, string v, Statement statement1, Statement statement2) : base(context)
        {

            this.v = v;
            this.statement1 = statement1;
            this.statement2 = statement2;
        }
    }
}