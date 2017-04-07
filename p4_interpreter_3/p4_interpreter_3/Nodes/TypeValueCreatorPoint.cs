namespace p4_interpreter_3.expressions
{
    public class TypeValueCreatorPoint : Statement
    {

        private Statement statement1;
        private string v1;
        private Statement statement2;
        private string v2;

        public TypeValueCreatorPoint(ParserContext context, Statement statement1, string v1, Statement statement2, string v2) : base(context)
        {

            this.statement1 = statement1;
            this.v1 = v1;
            this.statement2 = statement2;
            this.v2 = v2;
        }
    }
}