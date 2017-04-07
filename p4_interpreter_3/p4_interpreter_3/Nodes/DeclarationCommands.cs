namespace p4_interpreter_3.expressions
{
    public class DeclarationCommands : Statement
    {
        private Statement statement1;
        private Statement statement2;

        public DeclarationCommands(ParserContext context, Statement statement1, Statement statement2) : base(context)
        {
            this.statement1 = statement1;
            this.statement2 = statement2;
        }

        public override string ToString()
        {
            string returnstring = "";

            if (statement1 != null)
            {
                returnstring = returnstring + " " + statement1.ToString() + " ";
            }
            if (statement2 != null)
            {
                returnstring = returnstring + " " + statement2.ToString() + " ";
            }

            return returnstring;
        }
    }
}

