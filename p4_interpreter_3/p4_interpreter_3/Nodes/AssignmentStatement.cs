namespace p4_interpreter_3.expressions
{
    public class AssignmentStatement : Statement
    {

        private Statement _statement;
        private Statement _statement2;
        private Statement _statement3;

        //                     //<Statement> ::= <Identifiers> '=' <Value> <Expression> ';'

        public AssignmentStatement(ParserContext context, Statement statement, Statement statement2, Statement statement3) : base(context)
        {
            _statement = statement;
            _statement2 = statement2;
            _statement3 = statement3;

        }


        public override void TypeCheck()
        {


        }

        public override void ScopeCheck()
        {
            base.ScopeCheck();
        }


        public override string ToString()
        {
            string returnstring = "";
            if (_statement != null)
            {
                returnstring = returnstring + " " + _statement.ToString() + " ";
            }
            if (_statement2 != null)
            {
                returnstring = returnstring + " " + _statement2.ToString() + " ";
            }
            if (_statement3 != null)
            {
                returnstring = returnstring + " " + _statement3.ToString() + " ";
            }
            return returnstring;
        }
    }
}