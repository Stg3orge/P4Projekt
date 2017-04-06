namespace p4_interpreter_3.expressions
{
    public class OperatorExpression : Expression
    {

        private Statement statement1;
        private Statement statement2;
        private Statement statement3;

        public OperatorExpression(ParserContext context, Statement statement1, Statement statement2, Statement statement3) : base(context)
        {

            this.statement1 = statement1;
            this.statement2 = statement2;
            this.statement3 = statement3;
        }

        public override object Value
        {
            get { return null; }
        }

        public override string ToString()
        {
            string returnstring = "";

            if (statement1 != null)
            {
                returnstring += " " + statement1.ToString() + " ";
            }
            if (statement2 != null)
            {
                returnstring += " " + statement2.ToString() + " ";
            }
            if (statement3 != null)
            {
                returnstring += " " + statement3.ToString() + " ";
            }

            return returnstring;
        }
    }
}